using System;
using System.Collections.Generic;

#nullable disable

namespace SanGiuseppe.Models
{
    public partial class Anagrafica
    {
        public Anagrafica()
        {
            AnagraficaRuoli = new HashSet<AnagraficaRuoli>();
            CapiGruppetto = new HashSet<CapiGruppetto>();
            FondoComune = new HashSet<FondoComune>();
            Utenti = new HashSet<Utenti>();
        }

        public int Idanagrafica { get; set; }
        public short? NumeroIscrizione { get; set; }
        public bool SanGiuseppe { get; set; }
        public string Cognome { get; set; }
        public string Nome { get; set; }
        public string Sesso { get; set; }
        public string LuogodiNascita { get; set; }
        public string DatadiNascita { get; set; }
        public string Cittadinanza { get; set; }

        public string Nazione { get; set; }
        public string Telefono { get; set; }
        public string Cellulare { get; set; }
        public string Email { get; set; }
        public string NumeroIscrizioneFraternità { get; set; }
        public string Gruppo { get; set; }
        public string Zona { get; set; }
        public DateTime? DataInizio { get; set; }
        public string Codfisc { get; set; }
        public string IndirizzoDomicilio { get; set; }
        public string CapDomicilio { get; set; }
        public string CittàDomicilio { get; set; }
        public string ProvinciaDomicilio { get; set; }
        public string NazioneDomicilio { get; set; }
        public string IndirizzoResidenza { get; set; }
        public string CapResidenza { get; set; }
        public string CittàResidenza { get; set; }
        public string ProvinciaResidenza { get; set; }
        public string NazioneResidenza { get; set; }
        public string Professione { get; set; }
        public bool? PartecipaRitiro { get; set; }
        public DateTime? PartecipaRitiroData { get; set; }
        public int? Albergo { get; set; }
        public string Camera { get; set; }
        public bool? CameraSingola { get; set; }
        public double? RitiroQuota { get; set; }
        public double? RitiroSupplentoSingola { get; set; }
        public double? RitiroImporto { get; set; }
        public double? RitiroPagamentoImporto { get; set; }
        public DateTime? RitiroPagamentoData { get; set; }
        public string RitiroPagamentoIdtransazione { get; set; }
        public string RitiroPagamentoCro { get; set; }
        public double? QuotaFondoComune { get; set; }
        public double? QuotaFondoComuneValuta { get; set; }
        public bool? EsenteFondoComune { get; set; }
        public string TipoPagamento { get; set; }
        public string Note { get; set; }
        public int? AnnoDiInizio { get; set; }
        public string DataLettera { get; set; }
        public bool? Nuovo { get; set; }
        public bool? Selezionato { get; set; }
        public bool? InviaEmail { get; set; }
        public string Lingua { get; set; }

        public Guid UID { get; set; }
        public virtual Visitor Visitor { get; set; }
        public virtual ICollection<AnagraficaRuoli> AnagraficaRuoli { get; set; }
        public virtual ICollection<CapiGruppetto> CapiGruppetto { get; set; }
        public virtual ICollection<FondoComune> FondoComune { get; set; }
        public virtual ICollection<Utenti> Utenti { get; set; }
    }
}
