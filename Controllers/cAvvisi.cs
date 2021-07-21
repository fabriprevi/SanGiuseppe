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
using Microsoft.Extensions.Configuration;
using SanGiuseppe.Models.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Session;
using System.IO;

namespace SanGiuseppe.Controllers
{
    public class cAvvisi : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SanGiuseppeContext _context;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IConfiguration _configuration;

        public Funzioni funzioni;
        public cAvvisi(ILogger<HomeController> logger,
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

        // GET: cAvvisi
        [Authorize]
        [HttpGet("/Avvisi/Index")]
        public IActionResult Index()
        {
            RiempiViewBag();
            var UIDUtente = HttpContext.Session.GetString("SanGiuseppeUIDUtente");
            var IDUtente = 0;
            if (UIDUtente != null)
            {
                IDUtente = _context.Utenti.SingleOrDefault(a => a.UID.ToString() == UIDUtente).Idutente;
            }
            if (IDUtente > 0)
            {
                //var avvisi = _context.Avvisi.Where(a =>
                //                a.AvvisiPermessi.Any(ap =>
                //                    ap.UtentiPermessi.Any(up => up.Idutente == IDUtente)))

                //    .Select(a => new Avvisi
                //    {
                //        Titolo = a.Titolo,
                //        Link = a.Link,
                //        Categoria = a.Categoria

                //    }).ToList();                

                var avvisi = _context.Avvisi
                    .Where(a => a.AvvisiPermessi.Any(ap => _context.UtentiPermessi.Where(up => up.Idutente == IDUtente).Select(up => up.Permesso).Contains(ap.Permesso)))
                    .Select(a => new Avvisi
                    {
                        Titolo = a.Titolo,
                        Link = a.Link.Trim().Replace(" ","%20"),
                        Categoria = a.Categoria,
                        Anno = a.Anno,
                        Colore = a.Colore,
                        Lingua = a.Lingua

                    }).Where(a=> a.Lingua == funzioni.ImpostaLingua())
                    .OrderByDescending(a => a.Anno).ToList();


                return View(avvisi);

            }
            return View();
        }
       [Authorize]
        [HttpPost("/Avvisi/Index")]
        public IActionResult Index([FromForm] dtoAvvisi formavvisi)
        {
            RiempiViewBag();
            var UIDUtente = HttpContext.Session.GetString("SanGiuseppeUIDUtente");
            var IDUtente = 0;
            if (UIDUtente != null)
            {
                IDUtente = _context.Utenti.SingleOrDefault(a => a.UID.ToString() == UIDUtente).Idutente;
            }
            if (IDUtente > 0)
            {

                var avvisi = _context.Avvisi
                    .Where(a => a.AvvisiPermessi.Any(ap => _context.UtentiPermessi.Where(up => up.Idutente == IDUtente).Select(up => up.Permesso).Contains(ap.Permesso)))
                    .Select(a => new Avvisi
                    {
                        Titolo = a.Titolo,
                        Link = a.Link,
                        Categoria = a.Categoria,
                        Anno = a.Anno,
                        Colore = a.Colore,
                        Lingua = a.Lingua

                    });

                if (formavvisi.Anno > 0)
                {
                    avvisi = avvisi.Where(a => a.Anno == formavvisi.Anno);
                }           
                             
                if (formavvisi.Lingua != null)
                {
                    avvisi = avvisi.Where(a => a.Lingua == formavvisi.Lingua);
                } else
                {
                    avvisi = avvisi.Where(a => a.Lingua == funzioni.ImpostaLingua());
                }          
                
                if (formavvisi.Categoria != null)
                {
                    avvisi = avvisi.Where(a => a.Categoria == formavvisi.Categoria);
                }
                        
                if (formavvisi.Testo != null)
                {
                    avvisi = avvisi.Where(a => a.Titolo.Contains(formavvisi.Testo));
                }

                avvisi = avvisi.OrderByDescending(a => a.Anno);
                return View(avvisi);

            }

            return View();
        }

        // GET: cAvvisi/Details/5
   
        // GET: cAvvisi/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: cAvvisi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Avvisi avvisi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(avvisi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(avvisi);
        }

        // GET: cAvvisi/Edit/5
  
        // GET: cAvvisi/Delete/5
        [Authorize]
        [HttpGet("/Avvisi/Delete/{UID:Guid}")]
        public IActionResult Delete(Guid UID)
        {
            var avvisi = _context.Avvisi.SingleOrDefault(a=>a.UID==UID);
            _context.Avvisi.Remove(avvisi);
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
           

            var anni = _context.Avvisi.GroupBy(a => a.Anno)
                .Select(a => new { Anno = a.Key }).OrderBy(a=>a.Anno).AsEnumerable();
            ViewBag.anni = anni;     
            
            var categorie = _context.Avvisi.GroupBy(a => a.Categoria)
                .Select(a => new { Categoria = a.Key }).OrderBy(a=>a.Categoria).AsEnumerable();
            ViewBag.categorie = categorie;
            return "";
        }
    }
}
