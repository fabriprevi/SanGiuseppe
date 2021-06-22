using System;
using System.Collections.Generic;

#nullable disable

namespace SanGiuseppe.Models
{
    public partial class dtoFondoComuneRequest
    {
        public int Id { get; set; }
        public int? Idanagrafica { get; set; }
        public int? Anno { get; set; }
        public double? Quota01 { get; set; }
        public double? Quota02 { get; set; }
        public double? Quota03 { get; set; }
        public double? Quota04 { get; set; }
        public double? Quota05 { get; set; }
        public double? Quota06 { get; set; }
        public double? Quota07 { get; set; }
        public double? Quota08 { get; set; }
        public double? Quota09 { get; set; }
        public double? Quota10 { get; set; }
        public double? Quota11 { get; set; }
        public double? Quota12 { get; set; }
        public double? Importo01 { get; set; }
        public double? Importo02 { get; set; }
        public double? Importo03 { get; set; }
        public double? Importo04 { get; set; }
        public double? Importo05 { get; set; }
        public double? Importo06 { get; set; }
        public double? Importo07 { get; set; }
        public double? Importo08 { get; set; }
        public double? Importo09 { get; set; }
        public double? Importo10 { get; set; }
        public double? Importo11 { get; set; }
        public double? Importo12 { get; set; }
        public DateTime? DataPagamento01 { get; set; }
        public DateTime? DataPagamento02 { get; set; }
        public DateTime? DataPagamento03 { get; set; }
        public DateTime? DataPagamento04 { get; set; }
        public DateTime? DataPagamento05 { get; set; }
        public DateTime? DataPagamento06 { get; set; }
        public DateTime? DataPagamento07 { get; set; }
        public DateTime? DataPagamento08 { get; set; }
        public DateTime? DataPagamento09 { get; set; }
        public DateTime? DataPagamento10 { get; set; }
        public DateTime? DataPagamento11 { get; set; }
        public DateTime? DataPagamento12 { get; set; }
        public string TipoPagamento01 { get; set; }
        public string TipoPagamento02 { get; set; }
        public string TipoPagamento03 { get; set; }
        public string TipoPagamento04 { get; set; }
        public string TipoPagamento05 { get; set; }
        public string TipoPagamento06 { get; set; }
        public string TipoPagamento07 { get; set; }
        public string TipoPagamento08 { get; set; }
        public string TipoPagamento09 { get; set; }
        public string TipoPagamento10 { get; set; }
        public string TipoPagamento11 { get; set; }
        public string TipoPagamento12 { get; set; }
        public string Valuta01 { get; set; }
        public string Valuta02 { get; set; }
        public string Valuta03 { get; set; }
        public string Valuta04 { get; set; }
        public string Valuta05 { get; set; }
        public string Valuta06 { get; set; }
        public string Valuta07 { get; set; }
        public string Valuta08 { get; set; }
        public string Valuta09 { get; set; }
        public string Valuta10 { get; set; }
        public string Valuta11 { get; set; }
        public string Valuta12 { get; set; }
        public string Note { get; set; }
        public Guid UID { get; set; }
        public virtual Anagrafica IdanagraficaNavigation { get; set; }
    }
}
