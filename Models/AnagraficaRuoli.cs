using System;
using System.Collections.Generic;

#nullable disable

namespace SanGuseppeNuovoSito.Models
{
    public partial class AnagraficaRuoli
    {
        public int IdanafraficaIncarico { get; set; }
        public int? Idanagrafica { get; set; }
        public string CodiceRuolo { get; set; }
        public DateTime? DataInizio { get; set; }
        public DateTime? Scadenza { get; set; }
    }
}
