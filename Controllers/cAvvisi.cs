using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Dynamic.Core;
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

        [Authorize]
        [HttpGet("/Avvisi/IndexBO")]
        public IActionResult IndexBO()
        {
            return View();
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
                        
                if (formavvisi.Contenuto != null)
                {
                    avvisi = avvisi.Where(a => a.Titolo.Contains(formavvisi.Contenuto));
                }

                avvisi = avvisi.OrderByDescending(a => a.Anno);
                return View(avvisi);

            }

            return View();
        }

     
    

        [Authorize]
        [HttpPost("/Avvisi/LoadData/")]
        public async Task<IActionResult> LoadData(Guid UID)
        {
            try
            {


                var avvisi = _context.Avvisi
                        .Select(a => new
                        {
                            dataf = a.Data.ToString("dd/MM/yyyy hh:mm"),
                            data = a.Data,
                            titolo = a.Titolo,
                            allegato = a.Link,
                            uid = a.UID

                        }); ;

                var draw = HttpContext.Request.Form["draw"].FirstOrDefault();
                // Skiping number of Rows count  
                var start = Request.Form["start"].FirstOrDefault();
                // Paging Length 10,20  
                var length = Request.Form["length"].FirstOrDefault();
                // Sort Column Name  
                var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
                // Sort Column Direction ( asc ,desc)  
                var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
                // Search Value from (Search box)  
                var searchValue = Request.Form["search[value]"].FirstOrDefault();

                //Paging Size (10,20,50,100)  
                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;

                if (!(string.IsNullOrEmpty(sortColumn) || string.IsNullOrEmpty(sortColumnDirection)))
                {
                    avvisi = avvisi.OrderBy(sortColumn + " " + sortColumnDirection);
                }

                if (!(string.IsNullOrEmpty(searchValue) || string.IsNullOrEmpty(searchValue)))
                {
                    avvisi = avvisi.Where(a => a.titolo.Contains(searchValue));
                }
                // total number of rows count   
                var recordsTotal = avvisi.Count();

                // paging   
                var data = avvisi.Skip(skip).Take(pageSize).ToList();
                //Returning Json Data  
                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

       

        /// //////////////////////////////////// CREAZIONE AVVISI
      
        
        
        [Authorize]
        [HttpGet("/Avvisi/Create")]
        public IActionResult Create()
        {
            RiempiViewBag();
            return View();
        }

        
        [Authorize]
        [HttpPost("/Avvisi/Create")]

        public string Create([FromForm] dtoAvvisi avvisi)
        {
            var nomefile = "";
            if (ModelState.IsValid)
            {
                if (avvisi.attachment != null)
                {
                    if (avvisi.attachment.Length > 0)
                    {

                        var filePath = Directory.GetCurrentDirectory() + "/wwwroot/allegati/avvisi/" + avvisi.attachment.FileName;
                        nomefile = avvisi.attachment.FileName; 
                        using (var stream = System.IO.File.Create(filePath))
                        {
                            avvisi.attachment.CopyTo(stream);
                        }
                    }
                }



                var inserimentoAvviso = new Avvisi();
                inserimentoAvviso.Ordinamento = avvisi.Ordinamento;
                inserimentoAvviso.Titolo = avvisi.Titolo;
                inserimentoAvviso.Contenuto = avvisi.Contenuto;
                inserimentoAvviso.Link = nomefile;
                inserimentoAvviso.Visibile = avvisi.Visibile;
                inserimentoAvviso.Data = avvisi.Data;
                inserimentoAvviso.Anno = avvisi.Data.Year;
                inserimentoAvviso.Lingua = avvisi.Lingua;
                inserimentoAvviso.Categoria = avvisi.Categoria;
                inserimentoAvviso.Colore = avvisi.Colore;

                _context.Add(inserimentoAvviso);
                _context.SaveChangesAsync();
                return "AVVISO INSERITO";
            }
            return "ERROR IN INSERINENTO AVVISO";
        }




        /// //////////////////////////////////// MODIFICA AVVISI


        [Authorize]
        [HttpGet("/Avvisi/Edit/{UID:Guid}")]
        public IActionResult Edit(Guid UID)
        {
            RiempiViewBag();
            var avviso = _context.Avvisi.SingleOrDefault(a => a.UID == UID);
            return View(avviso);
        }
       [Authorize]
       [HttpPost("/Avvisi/Edit/")]
        public IActionResult Edit([FromForm] dtoAvvisi avvisi)
        {
            var nomefile = "";
            try
            {

            
            if (avvisi.attachment != null)
            {
                if (avvisi.attachment.Length > 0)
                {

                    var filePath = Directory.GetCurrentDirectory() + "/wwwroot/allegati/avvisi/" + avvisi.attachment.FileName;
                    nomefile = avvisi.attachment.FileName;
                    using (var stream = System.IO.File.Create(filePath))
                    {
                        avvisi.attachment.CopyTo(stream);
                    }
                }
            }
            }
            catch (Exception ex)
            {
                nomefile = "";
            }



            var modificaavviso = _context.Avvisi.SingleOrDefault(a => a.UID == avvisi.UID);
            modificaavviso.Ordinamento = avvisi.Ordinamento;
            modificaavviso.Titolo = avvisi.Titolo;
            modificaavviso.Contenuto = avvisi.Contenuto;
            if (nomefile != "") { modificaavviso.Link = nomefile; }

            modificaavviso.Visibile = avvisi.Visibile;
            modificaavviso.Data = avvisi.Data;
            modificaavviso.Anno = avvisi.Data.Year;
            modificaavviso.Lingua = avvisi.Lingua;
            modificaavviso.Categoria = avvisi.Categoria;
            modificaavviso.Colore = avvisi.Colore;

            _context.Update(modificaavviso);
            _context.SaveChanges();
            RiempiViewBag();
            return View(modificaavviso);
        }

        // GET: cAvvisi/Delete/5
        [Authorize]
        [HttpGet("/Avvisi/Delete/{UID:Guid}")]
        public IActionResult Delete(Guid UID)
        {
            try
            {

           
            var avvisi = _context.Avvisi.SingleOrDefault(a=>a.UID==UID);
            _context.Avvisi.Remove(avvisi);
             _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View();
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
                .Select(a => new { Anno = a.Key }).OrderBy(a=>a.Anno).ToList();
            ViewBag.anni = anni;     
            
            var categorie = _context.Avvisi.GroupBy(a => a.Categoria)
                .Select(a => new { Categoria = a.Key }).OrderBy(a=>a.Categoria).ToList();
            ViewBag.categorie = categorie;            
            
            var colori = _context.Avvisi.GroupBy(a => a.Colore)
                .Select(a => new { Colore = a.Key }).OrderBy(a=>a.Colore).ToList();
            ViewBag.colori  = colori;
            return "";
        }
    }
}
