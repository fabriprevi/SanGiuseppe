using System;
using System.Collections.Generic;

#nullable disable

namespace SanGiuseppe.Models
{
    public partial class Dizionario
    {
        public int Id { get; set; }
        public string Chiave { get; set; }
        public string Traduzione { get; set; }
        public string Lingua { get; set; }
    }
}
