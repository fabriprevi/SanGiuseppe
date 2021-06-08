using System;
using System.Collections.Generic;

#nullable disable

namespace SanGiuseppe.Models
{
    public partial class AnagraficaRuoli
    {
        public int IdanafraficaIncarico { get; set; }
        public int? Idanagrafica { get; set; }
        public string CodiceRuolo { get; set; }
        public DateTime? DataInizio { get; set; }
        public DateTime? Scadenza { get; set; }

        public virtual Anagrafica IdanagraficaNavigation { get; set; }
    }
}
