using System;
using System.Collections.Generic;

#nullable disable

namespace SanGuseppeNuovoSito.Models
{
    public partial class Utenti
    {
        public int Idanagrafica { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Gruppo { get; set; }
        public int? Comunità { get; set; }
        public DateTime? DataultimaModificaPassword { get; set; }
    }
}
