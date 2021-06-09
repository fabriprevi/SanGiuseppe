﻿using System;
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
    public class cAnagrafica : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SanGiuseppeContext _context;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IConfiguration _configuration;

        public Funzioni funzioni;
        public cAnagrafica(ILogger<HomeController> logger,
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

        // GET: cAnagrafica
        public async Task<IActionResult> Index()
        {
            return View(await _context.Anagrafica.ToListAsync());
        }

        // GET: cAnagrafica/Details/5
   
        // GET: cAnagrafica/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: cAnagrafica/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(dtoAnagrafica anagrafica)
        {
            if (ModelState.IsValid)
            {
                _context.Add(anagrafica);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(anagrafica);
        }

        // GET: cAnagrafica/Edit/5
        [Authorize]
        [HttpGet("/Anagrafica/Edit")]
        public async Task<IActionResult> Edit()
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
            var anagrafica = await _context.Anagrafica
                .Select(a=> new dtoAnagrafica
                {
                    Albergo = a.Albergo,
                    AnnoDiInizio = a.AnnoDiInizio,
                    Camera = a.Camera,
                    CameraSingola = a.CameraSingola,
                    CapDomicilio = a.CapDomicilio,
                    CapResidenza = a.CapResidenza,
                    Cellulare = a.Cellulare,
                    Cittadinanza = a.Cittadinanza,
                    CittàDomicilio = a.CittàDomicilio,
                    CittàResidenza = a.CittàResidenza,
                    Codfisc = a.Codfisc,
                    Cognome = a.Cognome,
                    DatadiNascita = a.DatadiNascita,
                    DataInizio = a.DataInizio,
                    DataLettera = a.DataLettera,
                    Email = a.Email,
                    EsenteFondoComune = a.EsenteFondoComune,
                    Gruppo = a.Gruppo,
                    Idanagrafica = a.Idanagrafica,
                    IndirizzoDomicilio = a.IndirizzoDomicilio,
                    IndirizzoResidenza = a.IndirizzoResidenza,
                    InviaEmail = a.InviaEmail,
                    Lingua = a.Lingua,
                    LuogodiNascita = a.LuogodiNascita,
                    Nazione = a.Nazione,
                    NazioneDomicilio = a.NazioneDomicilio,
                    NazioneResidenza = a.NazioneResidenza,
                    Nome = a.Nome,
                    Note = a.Note,
                    NumeroIscrizione = a.NumeroIscrizione,
                    NumeroIscrizioneFraternità = a.NumeroIscrizioneFraternità,
                    Nuovo = a.Nuovo,
                    PartecipaRitiro = a.PartecipaRitiro,
                    PartecipaRitiroData = a.PartecipaRitiroData,
                    Professione = a.Professione,
                    ProvinciaDomicilio = a.ProvinciaDomicilio,
                    ProvinciaResidenza = a.ProvinciaResidenza,
                    QuotaFondoComune = a.QuotaFondoComune,
                    QuotaFondoComuneValuta = a.QuotaFondoComuneValuta,
                    RitiroImporto = a.RitiroImporto,
                    RitiroPagamentoCro = a.RitiroPagamentoCro,
                    RitiroPagamentoData = a.RitiroPagamentoData,
                    RitiroPagamentoIdtransazione = a.RitiroPagamentoIdtransazione,
                    RitiroPagamentoImporto = a.RitiroPagamentoImporto,
                    RitiroQuota = a.RitiroQuota,
                    RitiroSupplentoSingola = a.RitiroSupplentoSingola,
                    SanGiuseppe = a.SanGiuseppe,
                    Selezionato = a.Selezionato,
                    Sesso = a.Sesso,
                    Telefono = a.Telefono,
                    TipoPagamento = a.TipoPagamento,
                    UID = a.UID,
                    Zona = a.Zona

                })
                .SingleOrDefaultAsync(a=>a.UID.ToString() == UID);
            if (anagrafica == null)
            {
                return NotFound();
            }
            return View(anagrafica);
        }

        // POST: cAnagrafica/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromForm] dtoAnagrafica anagrafica)
        {
           

            if (ModelState.IsValid)
            {
                try
                {
                    var anagraficadamodificare = await _context.Anagrafica.SingleOrDefaultAsync(a => a.UID == anagrafica.UID);
                    if(anagraficadamodificare!=null)
                    {
                        anagraficadamodificare.Albergo = anagrafica.Albergo;
                        anagraficadamodificare.AnnoDiInizio = anagrafica.AnnoDiInizio;
                        anagraficadamodificare.Camera = anagrafica.Camera;
                        anagraficadamodificare.CameraSingola = anagrafica.CameraSingola;
                        anagraficadamodificare.CapDomicilio = anagrafica.CapDomicilio;
                        anagraficadamodificare.CapResidenza = anagrafica.CapResidenza;
                        anagraficadamodificare.Cellulare = anagrafica.Cellulare;
                        anagraficadamodificare.Cittadinanza = anagrafica.Cittadinanza;
                        anagraficadamodificare.CittàDomicilio = anagrafica.CittàDomicilio;
                        anagraficadamodificare.CittàResidenza = anagrafica.CittàResidenza;
                        anagraficadamodificare.Codfisc = anagrafica.Codfisc;
                        anagraficadamodificare.Cognome = anagrafica.Cognome;
                        anagraficadamodificare.DatadiNascita = anagrafica.DatadiNascita;
                        anagraficadamodificare.DataInizio = anagrafica.DataInizio;
                        anagraficadamodificare.DataLettera = anagrafica.DataLettera;
                        anagraficadamodificare.Email = anagrafica.Email;
                        anagraficadamodificare.EsenteFondoComune = anagrafica.EsenteFondoComune;
                        anagraficadamodificare.Gruppo = anagrafica.Gruppo;
                        anagraficadamodificare.Idanagrafica = anagrafica.Idanagrafica;
                        anagraficadamodificare.IndirizzoDomicilio = anagrafica.IndirizzoDomicilio;
                        anagraficadamodificare.IndirizzoResidenza = anagrafica.IndirizzoResidenza;
                        anagraficadamodificare.InviaEmail = anagrafica.InviaEmail;
                        anagraficadamodificare.Lingua = anagrafica.Lingua;
                        anagraficadamodificare.LuogodiNascita = anagrafica.LuogodiNascita;
                        anagraficadamodificare.Nazione = anagrafica.Nazione;
                        anagraficadamodificare.NazioneDomicilio = anagrafica.NazioneDomicilio;
                        anagraficadamodificare.NazioneResidenza = anagrafica.NazioneResidenza;
                        anagraficadamodificare.Nome = anagrafica.Nome;
                        anagraficadamodificare.Note = anagrafica.Note;
                        anagraficadamodificare.NumeroIscrizione = anagrafica.NumeroIscrizione;
                        anagraficadamodificare.NumeroIscrizioneFraternità = anagrafica.NumeroIscrizioneFraternità;
                        anagraficadamodificare.Nuovo = anagrafica.Nuovo;
                        anagraficadamodificare.PartecipaRitiro = anagrafica.PartecipaRitiro;
                        anagraficadamodificare.PartecipaRitiroData = anagrafica.PartecipaRitiroData;
                        anagraficadamodificare.Professione = anagrafica.Professione;
                        anagraficadamodificare.ProvinciaDomicilio = anagrafica.ProvinciaDomicilio;
                        anagraficadamodificare.ProvinciaResidenza = anagrafica.ProvinciaResidenza;
                        anagraficadamodificare.QuotaFondoComune = anagrafica.QuotaFondoComune;
                        anagraficadamodificare.QuotaFondoComuneValuta = anagrafica.QuotaFondoComuneValuta;
                        anagraficadamodificare.RitiroImporto = anagrafica.RitiroImporto;
                        anagraficadamodificare.RitiroPagamentoCro = anagrafica.RitiroPagamentoCro;
                        anagraficadamodificare.RitiroPagamentoData = anagrafica.RitiroPagamentoData;
                        anagraficadamodificare.RitiroPagamentoIdtransazione = anagrafica.RitiroPagamentoIdtransazione;
                        anagraficadamodificare.RitiroPagamentoImporto = anagrafica.RitiroPagamentoImporto;
                        anagraficadamodificare.RitiroQuota = anagrafica.RitiroQuota;
                        anagraficadamodificare.RitiroSupplentoSingola = anagrafica.RitiroSupplentoSingola;
                        anagraficadamodificare.SanGiuseppe = anagrafica.SanGiuseppe;
                        anagraficadamodificare.Selezionato = anagrafica.Selezionato;
                        anagraficadamodificare.Sesso = anagrafica.Sesso;
                        anagraficadamodificare.Telefono = anagrafica.Telefono;
                        anagraficadamodificare.TipoPagamento = anagrafica.TipoPagamento;
                        anagraficadamodificare.UID = anagrafica.UID;
                        anagraficadamodificare.Zona = anagrafica.Zona;

                    }
                    _context.Update(anagrafica);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnagraficaExists(anagrafica.Idanagrafica))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(anagrafica);
        }

        // GET: cAnagrafica/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anagrafica = await _context.Anagrafica
                .FirstOrDefaultAsync(m => m.Idanagrafica == id);
            if (anagrafica == null)
            {
                return NotFound();
            }

            return View(anagrafica);
        }

        // POST: cAnagrafica/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var anagrafica = await _context.Anagrafica.FindAsync(id);
            _context.Anagrafica.Remove(anagrafica);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnagraficaExists(int id)
        {
            return _context.Anagrafica.Any(e => e.Idanagrafica == id);
        }

        private string RiempiViewBag()
        {

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