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
    public class cTabellaZone : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SanGiuseppeContext _context;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IConfiguration _configuration;

        public Funzioni funzioni;
        public cTabellaZone(ILogger<HomeController> logger,
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

        // GET: cTabellaZone
        [Authorize]
        [HttpGet("/TabellaZone/Index")]
        public async Task<IActionResult> Index()
        {
            RiempiViewBag();
            return View();
        }

        // GET: cTabellaZone/Details/5
   
        // GET: cTabellaZone/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: cTabellaZone/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost("/TabellaZone/Create")]

        public String Create(string zona)
        {
            var msg = "";
            try
            {
                var tabellazone = new TabellaZone();
                tabellazone.Zona = zona;

                _context.Add(tabellazone);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                msg =  ex.Message.ToString() ;
            }

           
  
            return msg;
        }

    

        // GET: cTabellaZone/Delete/5
        [Authorize]
        [HttpGet("/TabellaZone/Delete/{Zona}")]
        public string Delete(String Zona)
        {
            var TabellaZone = _context.TabellaZone.SingleOrDefault(a=>a.Zona==Zona);
            _context.TabellaZone.Remove(TabellaZone);
             _context.SaveChanges();
            return "";
        }

        [Authorize]
        [HttpPost("/TabellaZone/LoadData/")]
        public async Task<IActionResult> LoadData(Guid UID)
        {
            try
            {


                var tabellazone = _context.TabellaZone
                        .Select(a => new
                        {

                            Zona = a.Zona,

                        });

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
                    tabellazone = tabellazone.OrderBy(sortColumn + " " + sortColumnDirection);
                }

                // total number of rows count   
                var recordsTotal = tabellazone.Count();

                // paging   
                var data = tabellazone.Skip(skip).Take(pageSize).ToList();
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
      
            return "";
        }
    }
}
