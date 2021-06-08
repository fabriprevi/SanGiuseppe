using System;
using System.Collections.Generic;

#nullable disable

namespace SanGiuseppe.Models
{
    public partial class TabellaCitta
    {
        public int Idcitta { get; set; }
        public string Citta { get; set; }
        public string Regione { get; set; }
        public string Nazione { get; set; }
        public string Cap { get; set; }
        public string Provincia { get; set; }
        public string PrefissoTelefonico { get; set; }
        public bool Cappario { get; set; }
    }
}
