using System;
using System.Collections.Generic;

#nullable disable

namespace SanGiuseppe.Models
{
    public partial class AnagraficaPrimaDelleModifiche
    {
        public int Id { get; set; }
        public int Idsocio { get; set; }
        public short? NumeroIscrizione { get; set; }
        public string Cognome { get; set; }
        public string Nome { get; set; }
        public string Sesso { get; set; }
        public string LuogodiNascita { get; set; }
        public DateTime? DatadiNascita { get; set; }
        public string Cittadinanza { get; set; }
        public string Nazione { get; set; }
        public string Provincia { get; set; }
        public string Telefono1 { get; set; }
        public string Telefono2 { get; set; }
        public string Cellulare { get; set; }
        public string Email { get; set; }
        public string NumeroIscrizioneFraternità { get; set; }
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
        public string DescrizioneProfessione { get; set; }
        public string LuogoDiLavoro { get; set; }
        public double? QuotaFondoComune { get; set; }
        public double? QuotaFondoCarita { get; set; }
        public string TipoPagamento { get; set; }
    }
}
