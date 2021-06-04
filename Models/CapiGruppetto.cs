using System;
using System.Collections.Generic;

#nullable disable

namespace SanGuseppeNuovoSito.Models
{
    public partial class CapiGruppetto
    {
        public int IdcapoGruppetto { get; set; }
        public int? Idanagrafica { get; set; }
        public int? Idgruppetto { get; set; }
        public DateTime? DataInizio { get; set; }
        public DateTime? Scadenza { get; set; }
    }
}
