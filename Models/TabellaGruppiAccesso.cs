using System;
using System.Collections.Generic;

#nullable disable

namespace SanGiuseppe.Models
{
    public partial class TabellaGruppiAccesso
    {
        public int? Gruppo { get; set; }
        public string Descrizione { get; set; }
        public bool? IsAdmin { get; set; }
    }
}
