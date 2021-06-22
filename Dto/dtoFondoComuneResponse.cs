using System;
using System.Collections.Generic;

#nullable disable

namespace SanGiuseppe.Models.Dto
{
    public partial class dtoFondoComuneResponse
    {
        public int Id { get; set; }
        public int? Idanagrafica { get; set; }
        public int? Anno { get; set; }
        public string Quota01 { get; set; }
        public string Quota02 { get; set; }
        public string Quota03 { get; set; }
        public string Quota04 { get; set; }
        public string Quota05 { get; set; }
        public string Quota06 { get; set; }
        public string Quota07 { get; set; }
        public string Quota08 { get; set; }
        public string Quota09 { get; set; }
        public string Quota10 { get; set; }
        public string Quota11 { get; set; }
        public string Quota12 { get; set; }
        public string Importo01 { get; set; }
        public string Importo02 { get; set; }
        public string Importo03 { get; set; }
        public string Importo04 { get; set; }
        public string Importo05 { get; set; }
        public string Importo06 { get; set; }
        public string Importo07 { get; set; }
        public string Importo08 { get; set; }
        public string Importo09 { get; set; }
        public string Importo10 { get; set; }
        public string Importo11 { get; set; }
        public string Importo12 { get; set; }
        public string DataPagamento01 { get; set; }
        public string DataPagamento02 { get; set; }
        public string DataPagamento03 { get; set; }
        public string DataPagamento04 { get; set; }
        public string DataPagamento05 { get; set; }
        public string DataPagamento06 { get; set; }
        public string DataPagamento07 { get; set; }
        public string DataPagamento08 { get; set; }
        public string DataPagamento09 { get; set; }
        public string DataPagamento10 { get; set; }
        public string DataPagamento11 { get; set; }
        public string DataPagamento12 { get; set; }
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
       public Guid AnagraficaUID { get; set; }
        public virtual Anagrafica IdanagraficaNavigation { get; set; }
    }
}
