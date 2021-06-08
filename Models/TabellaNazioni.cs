using System;
using System.Collections.Generic;

#nullable disable

namespace SanGiuseppe.Models
{
    public partial class TabellaNazioni
    {
        public TabellaNazioni()
        {
            Visitor = new HashSet<Visitor>();
        }

        public string SiglaNazione { get; set; }
        public string Nazione { get; set; }
        public string NazioneUk { get; set; }
        public string NazioneEsp { get; set; }
        public string NazionePor { get; set; }
        public string PrefissoInternazionale { get; set; }
        public string CodiceValuta { get; set; }

        public virtual ICollection<Visitor> Visitor { get; set; }
    }
}
