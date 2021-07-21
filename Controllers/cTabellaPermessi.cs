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
    public class cTabellaPermessi : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SanGiuseppeContext _context;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IConfiguration _configuration;

        public Funzioni funzioni;
        public cTabellaPermessi(ILogger<HomeController> logger,
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

        // GET: cTabellaPermessi
        [Authorize]
        [HttpGet("/TabellaPermessi/Index")]
        public async Task<IActionResult> Index()
        {
            RiempiViewBag();
            return View();
        }

        // GET: cTabellaPermessi/Details/5
   
        // GET: cTabellaPermessi/Create
        public IActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost("/TabellaPermessi/Create")]

        public String Create(string permesso)
        {
            var msg = "";
            try
            {
                var tabellapermessi = new TabellaPermessi();
                tabellapermessi.Permesso = permesso;

                _context.Add(tabellapermessi);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                msg =  ex.Message.ToString() + " " + ex.InnerException.ToString();
            }

           
  
            return msg;
        }

    

        // GET: cTabellaPermessi/Delete/5
        [Authorize]
        [HttpGet("/TabellaPermessi/Delete/{Permesso}")]
        public string Delete(String Permesso)
        {
            var TabellaPermessi = _context.TabellaPermessi.SingleOrDefault(a=>a.Permesso==Permesso);
            _context.TabellaPermessi.Remove(TabellaPermessi);
             _context.SaveChanges();
            return "";
        }

        [Authorize]
        [HttpPost("/TabellaPermessi/LoadData/")]
        public async Task<IActionResult> LoadData(Guid UID)
        {
            try
            {


                var tabellapermessi = _context.TabellaPermessi
                        .Select(a => new
                        {

                            Permesso = a.Permesso,

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
                    tabellapermessi = tabellapermessi.OrderBy(sortColumn + " " + sortColumnDirection);
                }

                // total number of rows count   
                var recordsTotal = tabellapermessi.Count();

                // paging   
                var data = tabellapermessi.Skip(skip).Take(pageSize).ToList();
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
