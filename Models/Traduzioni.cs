using System;
using System.Collections.Generic;

#nullable disable

namespace SanGuseppeNuovoSito.Models
{
    public partial class Traduzioni
    {
        public int Id { get; set; }
        public string Chiave { get; set; }
        public string Lingua { get; set; }
        public string Traduzione { get; set; }
        public string Pagina { get; set; }
    }
}
