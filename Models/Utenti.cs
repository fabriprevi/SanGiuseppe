using System;
using System.Collections.Generic;

#nullable disable

namespace SanGiuseppe.Models
{
    public partial class Utenti
    {
        public int Idutente { get; set; }
        public int Idanagrafica { get; set; }
        public string Username { get; set; }
        public string VecchiaUsername { get; set; }
        public string Password { get; set; }
        public string Gruppo { get; set; }
        public int? Comunità { get; set; }
        public DateTime? DataultimaModificaPassword { get; set; }

        public virtual Anagrafica IdanagraficaNavigation { get; set; }
    }
}
