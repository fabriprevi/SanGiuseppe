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

namespace SanGiuseppe.Controllers
{
    public class cFondoComune : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SanGiuseppeContext _context;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IConfiguration _configuration;

        public Funzioni funzioni;
        public cFondoComune(ILogger<HomeController> logger,
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

        // GET: cFondoComune
        public async Task<IActionResult> Index()
        {
            return View(await _context.FondoComune.ToListAsync());
        }

        // GET: cFondoComune/Details/5
   
        // GET: cFondoComune/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: cFondoComune/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(dtoFondoComuneResponse fondocomune)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fondocomune);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fondocomune);
        }



        [Authorize]
        [HttpGet("/FondoComune/Details")]
        public IActionResult Details()
        {
            string UID = "";
            if (HttpContext.Session.GetString("SanGiuseppeUIDAnagrafica") != null)
            {
                UID = HttpContext.Session.GetString("SanGiuseppeUIDAnagrafica").ToString();
            }

            if (UID == null || UID == "")
            {
                return NotFound();
            }
            RiempiViewBag();
            var fondocomune = _context.FondoComune
                .Select(a => new dtoFondoComuneResponse
                {
                    Id = a.Id,
                    Idanagrafica = a.Idanagrafica,
                    Anno = a.Anno,
                    Quota01 = a.Quota01.Value.ToString("#,###.#0"),
                    Quota02 = a.Quota02.Value.ToString("#,###.#0"),
                    Quota03 = a.Quota03.Value.ToString("#,###.#0"),
                    Quota04 = a.Quota04.Value.ToString("#,###.#0"),
                    Quota05 = a.Quota05.Value.ToString("#,###.#0"),
                    Quota06 = a.Quota06.Value.ToString("#,###.#0"),
                    Quota07 = a.Quota07.Value.ToString("#,###.#0"),
                    Quota08 = a.Quota08.Value.ToString("#,###.#0"),
                    Quota09 = a.Quota09.Value.ToString("#,###.#0"),
                    Quota10 = a.Quota10.Value.ToString("#,###.#0"),
                    Quota11 = a.Quota11.Value.ToString("#,###.#0"),
                    Quota12 = a.Quota12.Value.ToString("#,###.#0"),
                    Importo01 = a.Importo01.Value.ToString("#,###.##"),
                    Importo02 = a.Importo02.Value.ToString("#,###.##"),
                    Importo03 = a.Importo03.Value.ToString("#,###.##"),
                    Importo04 = a.Importo04.Value.ToString("#,###.##"),
                    Importo05 = a.Importo05.Value.ToString("#,###.##"),
                    Importo06 = a.Importo06.Value.ToString("#,###.##"),
                    Importo07 = a.Importo07.Value.ToString("#,###.##"),
                    Importo08 = a.Importo08.Value.ToString("#,###.##"),
                    Importo09 = a.Importo09.Value.ToString("#,###.##"),
                    Importo10 = a.Importo10.Value.ToString("#,###.##"),
                    Importo11 = a.Importo11.Value.ToString("#,###.##"),
                    Importo12 = a.Importo12.Value.ToString("#,###.##"),
                    DataPagamento01 = a.DataPagamento01.Value.ToString("dd/MM/yyyy"),
                    DataPagamento02 = a.DataPagamento02.Value.ToString("dd/MM/yyyy"),
                    DataPagamento03 = a.DataPagamento03.Value.ToString("dd/MM/yyyy"),
                    DataPagamento04 = a.DataPagamento04.Value.ToString("dd/MM/yyyy"),
                    DataPagamento05 = a.DataPagamento05.Value.ToString("dd/MM/yyyy"),
                    DataPagamento06 = a.DataPagamento06.Value.ToString("dd/MM/yyyy"),
                    DataPagamento07 = a.DataPagamento07.Value.ToString("dd/MM/yyyy"),
                    DataPagamento08 = a.DataPagamento08.Value.ToString("dd/MM/yyyy"),
                    DataPagamento09 = a.DataPagamento09.Value.ToString("dd/MM/yyyy"),
                    DataPagamento10 = a.DataPagamento10.Value.ToString("dd/MM/yyyy"),
                    DataPagamento11 = a.DataPagamento11.Value.ToString("dd/MM/yyyy"),
                    DataPagamento12 = a.DataPagamento12.Value.ToString("dd/MM/yyyy"),
                    TipoPagamento01 = a.TipoPagamento01,
                    TipoPagamento02 = a.TipoPagamento02,
                    TipoPagamento03 = a.TipoPagamento03,
                    TipoPagamento04 = a.TipoPagamento04,
                    TipoPagamento05 = a.TipoPagamento05,
                    TipoPagamento06 = a.TipoPagamento06,
                    TipoPagamento07 = a.TipoPagamento07,
                    TipoPagamento08 = a.TipoPagamento08,
                    TipoPagamento09 = a.TipoPagamento09,
                    TipoPagamento10 = a.TipoPagamento10,
                    TipoPagamento11 = a.TipoPagamento11,
                    TipoPagamento12 = a.TipoPagamento12,
                    Valuta01 = a.Valuta01,
                    Valuta02 = a.Valuta02,
                    Valuta03 = a.Valuta03,
                    Valuta04 = a.Valuta04,
                    Valuta05 = a.Valuta05,
                    Valuta06 = a.Valuta06,
                    Valuta07 = a.Valuta07,
                    Valuta08 = a.Valuta08,
                    Valuta09 = a.Valuta09,
                    Valuta10 = a.Valuta10,
                    Valuta11 = a.Valuta11,
                    Valuta12 = a.Valuta12,
                    Note = a.Note,
                    AnagraficaUID = a.IdanagraficaNavigation.UID,
                    UID = a.UID
                })
                .Where(a => a.AnagraficaUID.ToString() == UID)
                .OrderByDescending(a=>a.Anno).ToList();
            if (fondocomune == null)
            {
                return NotFound();
            }
            return View(fondocomune);
        }
        [Authorize]
        [HttpGet("/FondoComune/DetailsBO/{UID:Guid}")]
        public IActionResult DetailsBO(Guid UID)
        {
          
            if (UID == null )
            {
                return NotFound();
            }
            RiempiViewBag();
            var fondocomune = _context.FondoComune
                .Select(a => new dtoFondoComuneResponse
                {
                    Id = a.Id,
                    Idanagrafica = a.Idanagrafica,
                    Anno = a.Anno,
                    Quota01 = a.Quota01.Value.ToString("#,###.#0"),
                    Quota02 = a.Quota02.Value.ToString("#,###.#0"),
                    Quota03 = a.Quota03.Value.ToString("#,###.#0"),
                    Quota04 = a.Quota04.Value.ToString("#,###.#0"),
                    Quota05 = a.Quota05.Value.ToString("#,###.#0"),
                    Quota06 = a.Quota06.Value.ToString("#,###.#0"),
                    Quota07 = a.Quota07.Value.ToString("#,###.#0"),
                    Quota08 = a.Quota08.Value.ToString("#,###.#0"),
                    Quota09 = a.Quota09.Value.ToString("#,###.#0"),
                    Quota10 = a.Quota10.Value.ToString("#,###.#0"),
                    Quota11 = a.Quota11.Value.ToString("#,###.#0"),
                    Quota12 = a.Quota12.Value.ToString("#,###.#0"),
                    Importo01 = a.Importo01.Value.ToString("#,###.##"),
                    Importo02 = a.Importo02.Value.ToString("#,###.##"),
                    Importo03 = a.Importo03.Value.ToString("#,###.##"),
                    Importo04 = a.Importo04.Value.ToString("#,###.##"),
                    Importo05 = a.Importo05.Value.ToString("#,###.##"),
                    Importo06 = a.Importo06.Value.ToString("#,###.##"),
                    Importo07 = a.Importo07.Value.ToString("#,###.##"),
                    Importo08 = a.Importo08.Value.ToString("#,###.##"),
                    Importo09 = a.Importo09.Value.ToString("#,###.##"),
                    Importo10 = a.Importo10.Value.ToString("#,###.##"),
                    Importo11 = a.Importo11.Value.ToString("#,###.##"),
                    Importo12 = a.Importo12.Value.ToString("#,###.##"),
                    DataPagamento01 = a.DataPagamento01.Value.ToString("dd/MM/yyyy"),
                    DataPagamento02 = a.DataPagamento02.Value.ToString("dd/MM/yyyy"),
                    DataPagamento03 = a.DataPagamento03.Value.ToString("dd/MM/yyyy"),
                    DataPagamento04 = a.DataPagamento04.Value.ToString("dd/MM/yyyy"),
                    DataPagamento05 = a.DataPagamento05.Value.ToString("dd/MM/yyyy"),
                    DataPagamento06 = a.DataPagamento06.Value.ToString("dd/MM/yyyy"),
                    DataPagamento07 = a.DataPagamento07.Value.ToString("dd/MM/yyyy"),
                    DataPagamento08 = a.DataPagamento08.Value.ToString("dd/MM/yyyy"),
                    DataPagamento09 = a.DataPagamento09.Value.ToString("dd/MM/yyyy"),
                    DataPagamento10 = a.DataPagamento10.Value.ToString("dd/MM/yyyy"),
                    DataPagamento11 = a.DataPagamento11.Value.ToString("dd/MM/yyyy"),
                    DataPagamento12 = a.DataPagamento12.Value.ToString("dd/MM/yyyy"),
                    TipoPagamento01 = a.TipoPagamento01,
                    TipoPagamento02 = a.TipoPagamento02,
                    TipoPagamento03 = a.TipoPagamento03,
                    TipoPagamento04 = a.TipoPagamento04,
                    TipoPagamento05 = a.TipoPagamento05,
                    TipoPagamento06 = a.TipoPagamento06,
                    TipoPagamento07 = a.TipoPagamento07,
                    TipoPagamento08 = a.TipoPagamento08,
                    TipoPagamento09 = a.TipoPagamento09,
                    TipoPagamento10 = a.TipoPagamento10,
                    TipoPagamento11 = a.TipoPagamento11,
                    TipoPagamento12 = a.TipoPagamento12,
                    Valuta01 = a.Valuta01,
                    Valuta02 = a.Valuta02,
                    Valuta03 = a.Valuta03,
                    Valuta04 = a.Valuta04,
                    Valuta05 = a.Valuta05,
                    Valuta06 = a.Valuta06,
                    Valuta07 = a.Valuta07,
                    Valuta08 = a.Valuta08,
                    Valuta09 = a.Valuta09,
                    Valuta10 = a.Valuta10,
                    Valuta11 = a.Valuta11,
                    Valuta12 = a.Valuta12,
                    Note = a.Note,
                    AnagraficaUID = a.IdanagraficaNavigation.UID,
                    UID = a.UID
                })
                .Where(a => a.AnagraficaUID == UID)
                .OrderByDescending(a=>a.Anno).ToList();
            if (fondocomune == null)
            {
                return NotFound();
            }
            return View(fondocomune);
        }


        // GET: cFondoComune/Edit/5
        [Authorize]
        [HttpGet("/FondoComune/Edit")]
        public async Task<IActionResult> Edit()
        {

            string UID = "";
            if (HttpContext.Session.GetString("SanGiuseppeUIDFondoComune") != null)
            {
                UID = HttpContext.Session.GetString("SanGiuseppeUIDFondoComune").ToString();
            }
            
            if (UID == null || UID == "")
            {
                return NotFound();
            }
            RiempiViewBag();
            var fondocomune = await _context.FondoComune
                .Select(a=> new dtoFondoComuneRequest
                {
                    Id = a.Id,
                    Idanagrafica = a.Idanagrafica,
                    Anno = a.Anno,
                    Quota01 = a.Quota01,
                    Quota02 = a.Quota02,
                    Quota03 = a.Quota03,
                    Quota04 = a.Quota04,
                    Quota05 = a.Quota05,
                    Quota06 = a.Quota06,
                    Quota07 = a.Quota07,
                    Quota08 = a.Quota08,
                    Quota09 = a.Quota09,
                    Quota10 = a.Quota10,
                    Quota11 = a.Quota11,
                    Quota12 = a.Quota12,
                    Importo01 = a.Importo01,
                    Importo02 = a.Importo02,
                    Importo03 = a.Importo03,
                    Importo04 = a.Importo04,
                    Importo05 = a.Importo05,
                    Importo06 = a.Importo06,
                    Importo07 = a.Importo07,
                    Importo08 = a.Importo08,
                    Importo09 = a.Importo09,
                    Importo10 = a.Importo10,
                    Importo11 = a.Importo11,
                    Importo12 = a.Importo12,
                    DataPagamento01 = a.DataPagamento01,
                    DataPagamento02 = a.DataPagamento02,
                    DataPagamento03 = a.DataPagamento03,
                    DataPagamento04 = a.DataPagamento04,
                    DataPagamento05 = a.DataPagamento05,
                    DataPagamento06 = a.DataPagamento06,
                    DataPagamento07 = a.DataPagamento07,
                    DataPagamento08 = a.DataPagamento08,
                    DataPagamento09 = a.DataPagamento09,
                    DataPagamento10 = a.DataPagamento10,
                    DataPagamento11 = a.DataPagamento11,
                    DataPagamento12 = a.DataPagamento12,
                    TipoPagamento01 = a.TipoPagamento01,
                    TipoPagamento02 = a.TipoPagamento02,
                    TipoPagamento03 = a.TipoPagamento03,
                    TipoPagamento04 = a.TipoPagamento04,
                    TipoPagamento05 = a.TipoPagamento05,
                    TipoPagamento06 = a.TipoPagamento06,
                    TipoPagamento07 = a.TipoPagamento07,
                    TipoPagamento08 = a.TipoPagamento08,
                    TipoPagamento09 = a.TipoPagamento09,
                    TipoPagamento10 = a.TipoPagamento10,
                    TipoPagamento11 = a.TipoPagamento11,
                    TipoPagamento12 = a.TipoPagamento12,
                    Valuta01 = a.Valuta01,
                    Valuta02 = a.Valuta02,
                    Valuta03 = a.Valuta03,
                    Valuta04 = a.Valuta04,
                    Valuta05 = a.Valuta05,
                    Valuta06 = a.Valuta06,
                    Valuta07 = a.Valuta07,
                    Valuta08 = a.Valuta08,
                    Valuta09 = a.Valuta09,
                    Valuta10 = a.Valuta10,
                    Valuta11 = a.Valuta11,
                    Valuta12 = a.Valuta12,
                    Note = a.Note,
                    UID = a.UID,


                })
                .SingleOrDefaultAsync(a=>a.UID.ToString() == UID);
            if (fondocomune == null)
            {
                return NotFound();
            }
            return View(fondocomune);
        }

        // POST: cFondoComune/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("/FondoComune/Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromForm] dtoFondoComuneRequest fondocomune)
        {
           

            if (ModelState.IsValid)
            {
                try
                {
                    var fondocomunedamodificare = await _context.FondoComune.SingleOrDefaultAsync(a => a.UID == fondocomune.UID);
                    if(fondocomunedamodificare!=null)
                    {
                        fondocomunedamodificare.Anno = fondocomune.Anno;
                        fondocomunedamodificare.Quota01 = fondocomune.Quota01;
                        fondocomunedamodificare.Quota02 = fondocomune.Quota02;
                        fondocomunedamodificare.Quota03 = fondocomune.Quota03;
                        fondocomunedamodificare.Quota04 = fondocomune.Quota04;
                        fondocomunedamodificare.Quota05 = fondocomune.Quota05;
                        fondocomunedamodificare.Quota06 = fondocomune.Quota06;
                        fondocomunedamodificare.Quota07 = fondocomune.Quota07;
                        fondocomunedamodificare.Quota08 = fondocomune.Quota08;
                        fondocomunedamodificare.Quota09 = fondocomune.Quota09;
                        fondocomunedamodificare.Quota10 = fondocomune.Quota10;
                        fondocomunedamodificare.Quota11 = fondocomune.Quota11;
                        fondocomunedamodificare.Quota12 = fondocomune.Quota12;
                        fondocomunedamodificare.Importo01 = fondocomune.Importo01;
                        fondocomunedamodificare.Importo02 = fondocomune.Importo02;
                        fondocomunedamodificare.Importo03 = fondocomune.Importo03;
                        fondocomunedamodificare.Importo04 = fondocomune.Importo04;
                        fondocomunedamodificare.Importo05 = fondocomune.Importo05;
                        fondocomunedamodificare.Importo06 = fondocomune.Importo06;
                        fondocomunedamodificare.Importo07 = fondocomune.Importo07;
                        fondocomunedamodificare.Importo08 = fondocomune.Importo08;
                        fondocomunedamodificare.Importo09 = fondocomune.Importo09;
                        fondocomunedamodificare.Importo10 = fondocomune.Importo10;
                        fondocomunedamodificare.Importo11 = fondocomune.Importo11;
                        fondocomunedamodificare.Importo12 = fondocomune.Importo12;
                        fondocomunedamodificare.DataPagamento01 = fondocomune.DataPagamento01;
                        fondocomunedamodificare.DataPagamento02 = fondocomune.DataPagamento02;
                        fondocomunedamodificare.DataPagamento03 = fondocomune.DataPagamento03;
                        fondocomunedamodificare.DataPagamento04 = fondocomune.DataPagamento04;
                        fondocomunedamodificare.DataPagamento05 = fondocomune.DataPagamento05;
                        fondocomunedamodificare.DataPagamento06 = fondocomune.DataPagamento06;
                        fondocomunedamodificare.DataPagamento07 = fondocomune.DataPagamento07;
                        fondocomunedamodificare.DataPagamento08 = fondocomune.DataPagamento08;
                        fondocomunedamodificare.DataPagamento09 = fondocomune.DataPagamento09;
                        fondocomunedamodificare.DataPagamento10 = fondocomune.DataPagamento10;
                        fondocomunedamodificare.DataPagamento11 = fondocomune.DataPagamento11;
                        fondocomunedamodificare.DataPagamento12 = fondocomune.DataPagamento12;
                        fondocomunedamodificare.TipoPagamento01 = fondocomune.TipoPagamento01;
                        fondocomunedamodificare.TipoPagamento02 = fondocomune.TipoPagamento02;
                        fondocomunedamodificare.TipoPagamento03 = fondocomune.TipoPagamento03;
                        fondocomunedamodificare.TipoPagamento04 = fondocomune.TipoPagamento04;
                        fondocomunedamodificare.TipoPagamento05 = fondocomune.TipoPagamento05;
                        fondocomunedamodificare.TipoPagamento06 = fondocomune.TipoPagamento06;
                        fondocomunedamodificare.TipoPagamento07 = fondocomune.TipoPagamento07;
                        fondocomunedamodificare.TipoPagamento08 = fondocomune.TipoPagamento08;
                        fondocomunedamodificare.TipoPagamento09 = fondocomune.TipoPagamento09;
                        fondocomunedamodificare.TipoPagamento10 = fondocomune.TipoPagamento10;
                        fondocomunedamodificare.TipoPagamento11 = fondocomune.TipoPagamento11;
                        fondocomunedamodificare.TipoPagamento12 = fondocomune.TipoPagamento12;
                        fondocomunedamodificare.Valuta01 = fondocomune.Valuta01;
                        fondocomunedamodificare.Valuta02 = fondocomune.Valuta02;
                        fondocomunedamodificare.Valuta03 = fondocomune.Valuta03;
                        fondocomunedamodificare.Valuta04 = fondocomune.Valuta04;
                        fondocomunedamodificare.Valuta05 = fondocomune.Valuta05;
                        fondocomunedamodificare.Valuta06 = fondocomune.Valuta06;
                        fondocomunedamodificare.Valuta07 = fondocomune.Valuta07;
                        fondocomunedamodificare.Valuta08 = fondocomune.Valuta08;
                        fondocomunedamodificare.Valuta09 = fondocomune.Valuta09;
                        fondocomunedamodificare.Valuta10 = fondocomune.Valuta10;
                        fondocomunedamodificare.Valuta11 = fondocomune.Valuta11;
                        fondocomunedamodificare.Valuta12 = fondocomune.Valuta12;
                        fondocomunedamodificare.Note = fondocomune.Note;
                        _context.Update(fondocomunedamodificare);

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
            return View(fondocomune);
        }

        // POST: cFondoComune/Delete/5
        [HttpPost("/FondoComune/Delete/{UID:Guid}")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Guid UID)
        {
            var fondocomune =  _context.FondoComune.FirstOrDefault(a => a.UID == UID);
            _context.FondoComune.Remove(fondocomune);

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
