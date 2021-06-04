using System;
using System.Collections.Generic;

#nullable disable

namespace SanGuseppeNuovoSito.Models
{
    public partial class Visitor
    {
        public int Idvisitor { get; set; }
        public int? Idanagrafica { get; set; }
        public DateTime? DataInizio { get; set; }
        public DateTime? Scadenza { get; set; }
    }
}
