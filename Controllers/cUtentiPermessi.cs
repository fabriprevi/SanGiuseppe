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
    public class cUtentiPermessi : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SanGiuseppeContext _context;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IConfiguration _configuration;

        public Funzioni funzioni;
        public cUtentiPermessi(ILogger<HomeController> logger,
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

        // GET: cUtentiPermessi
        public async Task<IActionResult> Index()
        {
            return View(await _context.UtentiPermessi.ToListAsync());
        }

        // GET: cUtentiPermessi/Details/5
   
        // GET: cUtentiPermessi/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: cUtentiPermessi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        
        [HttpPost("/UtentiPermessi/Create")]

        public IActionResult Create(Guid UID, String Permesso)
        {
         
                var utentipermessi = new UtentiPermessi();
                var utente = _context.Anagrafica.Select(a => new               
                {
                    UID = a.UID,
                    IDUtente = a.Utenti.FirstOrDefault().Idutente,
                }).SingleOrDefault(a => a.UID == UID);
                 
                if (utente.IDUtente > 0)
                {
                    utentipermessi.Idutente = utente.IDUtente;
                    utentipermessi.Permesso = Permesso;                
                    _context.Add(utentipermessi);
                    _context.SaveChanges();

                }
             
           
            return View();
        }

    
        // GET: cUtentiPermessi/Delete/5
        [Authorize]
        [HttpGet("/UtentiPermessi/Delete/{ID:int}")]
        public IActionResult Delete(int ID)
        {
            var UtentiPermessi = _context.UtentiPermessi.SingleOrDefault(a=>a.IdUtentePermesso==ID);
            _context.UtentiPermessi.Remove(UtentiPermessi);
             _context.SaveChanges();
            return View();
        }

        [Authorize]
        [HttpPost("/UtentiPermessi/LoadData/{UID:Guid}")]
        public async Task<IActionResult> LoadData(Guid UID)
        {
            try
            {

                var anagrafica = _context.Anagrafica.SingleOrDefault(a => a.UID == UID);
                if (anagrafica == null)
                {
                    return View();
                    
                };
                var utenti = _context.UtentiPermessi
                        .Select(a => new
                        {
                            IdUtentePermesso = a.IdUtentePermesso,
                            Permesso = a.Permesso,
                            IDUtente = a.Utenti.Idutente,
                            IDAnagrafica = a.Utenti.Idanagrafica == null ? 0 : a.Utenti.Idanagrafica
                        }).Where(a => a.IDAnagrafica == anagrafica.Idanagrafica);

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
                    utenti = utenti.OrderBy(sortColumn + " " + sortColumnDirection);
                }

                // total number of rows count   
                var recordsTotal = utenti.Count();

                // paging   
                var data = utenti.Skip(skip).Take(pageSize).ToList();
                //Returning Json Data  
                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });
            }
            catch (Exception ex)
            {
                throw ex;
            }

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
         
            
    
            
        
    

            ViewBag.lingua = lingue;
            return "";
        }
    }
}
