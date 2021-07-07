using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SanGiuseppe.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using SanGiuseppe.helpers;
using Microsoft.AspNetCore.Http;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

namespace SanGiuseppe.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SanGiuseppeContext _context;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IConfiguration _configuration;

        public Funzioni funzioni;

        public HomeController(ILogger<HomeController> logger, 
                                SanGiuseppeContext context, 
                                IHttpContextAccessor contextAccessor,
                                 IConfiguration conf)
        {
            _logger = logger;
            _context = context;
            _contextAccessor = contextAccessor;
            _configuration = conf;

            funzioni = new Funzioni(_context, _contextAccessor);
        }
        [HttpGet("/Login")]
        [HttpGet("/")]
        public IActionResult Login()
        {
            RiempiViewBag();
            return View();
        }

        [HttpPost("/Login")]
        public async Task<IActionResult> Login([FromForm] string Username, string Password)
        {


            var utente = _context.Utenti
                .Select(a => new
                {
                    IDAnagrafica = a.Idanagrafica,
                    Nominativo = a.IdanagraficaNavigation.Cognome + " " + a.IdanagraficaNavigation.Nome,
                    Username = a.Username,
                    Password = a.Password,
                    UIDAnagrafica = a.IdanagraficaNavigation.UID,
                    UIDUtente = a.UID,
                    Foto = a.IdanagraficaNavigation.UID.ToString() + ".jpg"


                }).SingleOrDefault(a => a.Username == Username && a.Password == Password);

            if (utente == null)
            {
                ViewBag.msg = funzioni.GetWord("Username o password errata");
                return View();
            }

            var sgClaims = new List<Claim>();
            sgClaims.Add(new Claim(ClaimTypes.PrimarySid, utente.IDAnagrafica.ToString()));
            sgClaims.Add(new Claim(ClaimTypes.Name, utente.Nominativo.ToString()));

            var sgIdentity = new ClaimsIdentity(sgClaims, "San Giuseppe Identity");
            var userPrincipal = new ClaimsPrincipal(new[] { sgIdentity });
            await HttpContext.SignInAsync("CookieAuthentication", userPrincipal);

            CookieOptions options = new CookieOptions();
            options.Expires = DateTime.Now.AddDays(1) ;
            options.HttpOnly = true;
            HttpContext.Response.Cookies.Append("SanGiuseppeIDAnagrafica", utente.IDAnagrafica.ToString(), options);
           HttpContext.Response.Cookies.Append("SanGiuseppeNominativo", utente.Nominativo, options);

            HttpContext.Session.SetString("SanGiuseppeIDAnagrafica", utente.IDAnagrafica.ToString());
              HttpContext.Session.SetString("SanGiuseppeNominativo", utente.Nominativo.ToString());
            HttpContext.Session.SetString("SanGiuseppeUIDAnagrafica", utente.UIDAnagrafica.ToString());
            HttpContext.Session.SetString("SanGiuseppeUIDUtente", utente.UIDUtente.ToString());
            HttpContext.Session.SetString("SanGiuseppeFoto", utente.Foto.ToString());

            return Redirect("/Home/IndexLogged");
        }


        [HttpGet("/Logout")]
        public async Task<IActionResult> Logout()
        {
            HttpContext.Response.Cookies.Delete("SanGiuseppeIDAnagrafica");
            HttpContext.Response.Cookies.Delete("SanGiuseppeNominativo");
            HttpContext.SignOutAsync();
            return Redirect("/");
        }



        [HttpGet("/SetLanguage/{language}")]
        public void setLanguage(string? language)
        {
            CookieOptions options = new CookieOptions();
            _contextAccessor.HttpContext.Response.Cookies.Delete("SanGiuseppeLingua");
            options.Expires = DateTime.Now.AddDays(-1D);

            if (String.IsNullOrEmpty(language))
            {
                _contextAccessor.HttpContext.Response.Cookies.Append("SanGiuseppeLingua", "it-IT", options);
            }
            else
            {
                _contextAccessor.HttpContext.Response.Cookies.Append("SanGiuseppeLingua", language, options);
            }
            options.Expires = DateTime.Now.AddDays(1D);
            _contextAccessor.HttpContext.Response.Cookies.Append("SanGiuseppeLingua", language, options);
           
        }
        [HttpGet("/Home/RecuperoPassword")]
        public IActionResult RecuperoPassword()
        {
            return View();
        }
            
        [HttpPost("/Home/RecuperoPassword")]
        public IActionResult RecuperoPassword(string Email)
        {
            RiempiViewBag();
            var utenti = _context.Utenti.FirstOrDefault(a => a.Username == Email);
            if (utenti != null)
            {

                var testo = "";
                var nomeparametro = "TESTORECUPEROPASSWORD_" + funzioni.ImpostaLingua();
                var emailDaSpedire = _context.TabellaParametri
                                        .Where(x => x.NomeParametro == nomeparametro)
                                        .Select(a => new { testo = a.ContenutoHtml }).FirstOrDefault();






                string to = "fprevidi@craon.it"; // emailDaSpedire.destinatario;
                string from = "nonrispondere@fraternitasangiuseppe.org";
                MailMessage message = new MailMessage(from, to);
                message.Subject = "Recupero password accesso al sito";
                message.Body = emailDaSpedire.testo
                    .Replace("##USERNAME##", utenti.Username.ToString())
                    .Replace("##PASSWORD##",utenti.Password.ToString()) ;
                message.IsBodyHtml = true;
                SmtpClient client = new SmtpClient(_configuration.GetValue<string>("SmtpServer"));
                // Credentials are necessary if the server requires the client
                // to authenticate before it will send email on the client's behalf.

                client.Credentials = new System.Net.NetworkCredential(_configuration.GetValue<string>("SmtpUsername"), _configuration.GetValue<string>("SmtpPassword"));

                try
                {
                    client.Send(message);
                    ViewBag.msg = funzioni.GetWord("Ti ha abbiamo spedito la password alla mail indicata");
                 }
                catch (Exception ex)
                {
                    ViewBag.msg = ex.Message.ToString();
                }

            }
              ViewBag.msg = funzioni.GetWord("Se presente nei nostri archivi la tua password ti verrà inviata alla mail indicata<BR><BR>" +
                  "Nel caso non ti venisse recapitata controlla prima la cartella della posta indesiderata");
         
            return View();

            
        }  
        



        
        [HttpGet("/Home/IndexLogged")]
        public IActionResult IndexLogged()
        {

            return View();
        }
        
 
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public string RiempiViewBag()
        {
            ViewBag.msg = "";
            return "";
        }
    }
}
