using System;
using System.Collections.Generic;

#nullable disable

namespace SanGiuseppe.Models
{
    public partial class Visitor
    {
        public int Idvisitor { get; set; }
        public int? Idanagrafica { get; set; }
        public DateTime? DataInizio { get; set; }
        public DateTime? Scadenza { get; set; }
        public string SiglaNazione { get; set; }
        public int Idgruppetto { get; set; }

        public virtual TabellaGruppetti IdgruppettoNavigation { get; set; }
        public virtual Anagrafica IdvisitorNavigation { get; set; }
        public virtual TabellaNazioni SiglaNazioneNavigation { get; set; }
    }
}
