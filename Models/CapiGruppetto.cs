using System;
using System.Collections.Generic;

#nullable disable

namespace SanGiuseppe.Models
{
    public partial class CapiGruppetto
    {
        public int IdcapoGruppetto { get; set; }
        public int? Idanagrafica { get; set; }
        public int? Idgruppetto { get; set; }
        public DateTime? DataInizio { get; set; }
        public DateTime? Scadenza { get; set; }

        public virtual Anagrafica IdanagraficaNavigation { get; set; }
        public virtual TabellaGruppetti IdcapoGruppettoNavigation { get; set; }
    }
}
