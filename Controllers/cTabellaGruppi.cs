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
    public class cTabellaGruppi : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SanGiuseppeContext _context;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IConfiguration _configuration;

        public Funzioni funzioni;
        public cTabellaGruppi(ILogger<HomeController> logger,
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

        // GET: cTabellaGruppi
        [Authorize]
        [HttpGet("/TabellaGruppi/Index")]
        public async Task<IActionResult> Index()
        {
            RiempiViewBag();
            return View();
        }

        // GET: cTabellaGruppi/Details/5
   
        // GET: cTabellaGruppi/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: cTabellaGruppi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost("/TabellaGruppi/Create")]

        public String Create(string gruppo)
        {
            var msg = "";
            try
            {
                var tabellagruppi = new TabellaGruppi();
                tabellagruppi.Gruppo = gruppo;

                _context.Add(tabellagruppi);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                msg =  ex.Message.ToString() ;
            }

           
  
            return msg;
        }

    

        // GET: cTabellaGruppi/Delete/5
        [Authorize]
        [HttpGet("/TabellaGruppi/Delete/{Gruppo}")]
        public string Delete(String Gruppo)
        {
            var TabellaGruppi = _context.TabellaGruppi.SingleOrDefault(a=>a.Gruppo==Gruppo);
            _context.TabellaGruppi.Remove(TabellaGruppi);
             _context.SaveChanges();
            return "";
        }

        [Authorize]
        [HttpPost("/TabellaGruppi/LoadData/")]
        public async Task<IActionResult> LoadData(Guid UID)
        {
            try
            {


                var tabellagruppi = _context.TabellaGruppi
                        .Select(a => new
                        {
                            Gruppo = a.Gruppo,

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
                    tabellagruppi = tabellagruppi.OrderBy(sortColumn + " " + sortColumnDirection);
                }

                if (!(string.IsNullOrEmpty(searchValue) || string.IsNullOrEmpty(searchValue)))
                {
                    tabellagruppi = tabellagruppi.Where(a => a.Gruppo.Contains(searchValue));
                }
                    // total number of rows count   
                    var recordsTotal = tabellagruppi.Count();

                // paging   
                var data = tabellagruppi.Skip(skip).Take(pageSize).ToList();
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
