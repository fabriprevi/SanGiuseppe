using System;
using System.Collections.Generic;

#nullable disable

namespace SanGiuseppe.Models
{
    public partial class Filtri
    {
        public int Id { get; set; }

        public string Tabella { get; set; }
        public string Campo { get; set; }
        public string Tipo { get; set; }
        public string Descrizione { get; set; }

    }
}
