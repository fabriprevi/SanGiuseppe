using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SanGiuseppe.helpers;
using SanGiuseppe.Models;
using SanGiuseppe.Models;

using Microsoft.Extensions.Configuration;
using SanGiuseppe.Models.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Session;
using System.IO;

namespace SanGiuseppe.Controllers
{
    public class cUtenti : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SanGiuseppeContext _context;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IConfiguration _configuration;

        public Funzioni funzioni;
        public cUtenti(ILogger<HomeController> logger,
                                SanGiuseppeContext context,
                                IHttpContextAccessor contextAccessor,
                                 IConfiguration conf )
        {
            _logger = logger;
            _context = context;
            _contextAccessor = contextAccessor;
            _configuration = conf;


            funzioni = new Funzioni(_context, _contextAccessor);
        }

        // GET: cUtenti
        public async Task<IActionResult> Index()
        {
            return View(await _context.Utenti.ToListAsync());
        }

        // GET: cUtenti/Details/5
   
        // GET: cUtenti/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: cUtenti/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Utenti utenti)
        {
            if (ModelState.IsValid)
            {
                _context.Add(utenti);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(utenti);
        }

        // GET: cUtenti/Edit/5
        [Authorize]
        [HttpGet("/Utenti/Edit")]
        public async Task<IActionResult> Edit()
        {
            // true
            // false

    
            string UID = "";
            if (HttpContext.Session.GetString("SanGiuseppeUIDUtenti") != null)
            {
                UID = HttpContext.Session.GetString("SanGiuseppeUIDUtenti").ToString();
            }
            
            if (UID == null || UID == "")
            {
                return NotFound();
            }
            RiempiViewBag();
            var utenti = await _context.Utenti
                .Select(a=> new 
                {
                    Idutente = a.Idutente,
                    Idanagrafica = a.Idanagrafica,
                    Username = a.Username,
                    Password = a.Password,
                    Gruppo = a.Gruppo,
                    UID = a.UID
                })
                .SingleOrDefaultAsync(a=>a.UID.ToString() == UID);
            if (utenti == null)
            {
                return NotFound();
            }
      
            return View(utenti);
        }

        // POST: cUtenti/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("/Utenti/Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromForm] Utenti utenti)
        {
          

    
            if (ModelState.IsValid)
            {
                try
                {
                    var utentidamodificare = await _context.Utenti.SingleOrDefaultAsync(a => a.UID == utenti.UID);
                    if(utentidamodificare!=null)
                    {
                        utentidamodificare.Idanagrafica = utenti.Idanagrafica;
                        utentidamodificare.Username = utenti.Username;
                        utentidamodificare.Password = utenti.Password;
                        utentidamodificare.Gruppo = utenti.Gruppo;                   
                        _context.Update(utentidamodificare);

                        await _context.SaveChangesAsync();

                    }
                  
                    RiempiViewBag();
                    ViewBag.msg = funzioni.GetWord("Dati aggiornati");
                }
                catch (Exception ex)
                {

                        ViewBag.msg = ex.Message + " " + ex.InnerException;

                }
             
            }
         
            return View(utenti);
        }      
        
        
        // POST: cUtenti/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpGet("/Utenti/ModificaPassword")]
        public async Task<IActionResult> ModificaPassword()
        {

            RiempiViewBag();

            if (HttpContext.Session.GetString("SanGiuseppeUIDUtente") != null)
            {
                try
                {
                    var UID = HttpContext.Session.GetString("SanGiuseppeUIDUtente");
                    var utenti = await _context.Utenti.SingleOrDefaultAsync(a => a.UID.ToString() == UID);
                    if(utenti==null)
                    {
                        ViewBag.msg = funzioni.GetWord("Record non trovato");
                    }

                    return View(utenti);
                }
                catch (Exception ex)
                {

                        ViewBag.msg = ex.Message + " " + ex.InnerException;

                }
             
            }

            return View();
        }

        // POST: cUtenti/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("/Utenti/ModificaPassword")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ModificaPassword([FromForm] Utenti utenti)
        {



            if (ModelState.IsValid)
            {
                try
                {
                    var utentidamodificare = await _context.Utenti.SingleOrDefaultAsync(a => a.UID == utenti.UID);
                    if (utentidamodificare != null)
                    {
                        utentidamodificare.Password = utenti.Password;
                        _context.Update(utentidamodificare);

                        await _context.SaveChangesAsync();

                    }

                    RiempiViewBag();
                    ViewBag.msg = funzioni.GetWord("Dati aggiornati");
                }
                catch (Exception ex)
                {

                    ViewBag.msg = ex.Message + " " + ex.InnerException;

                }

            }

            return View(utenti);
        }


        // GET: cUtenti/Delete/5
        [Authorize]
        [HttpGet("/Utenti/Delete/{UID:Guid}")]
        public IActionResult Delete(Guid UID)
        {
            var utenti = _context.Utenti.SingleOrDefault(a=>a.UID==UID);
            _context.Utenti.Remove(utenti);
             _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

     
        private string RiempiViewBag()
        {
            ViewBag.msg = "";
            var valute = _context.TabellaValute
                .Select(a => new { a.CodiceValuta, a.DescrizioneValuta })
                .OrderBy(b => b.DescrizioneValuta).ToList();
            ViewBag.valuta = valute;   
            
            var lingue = _context.TabellaLingue
                .Select(a => new { a.Lingua})
                .OrderBy(b => b.Lingua).ToList();
            ViewBag.lingua = lingue;
            return "";
        }
    }
}
