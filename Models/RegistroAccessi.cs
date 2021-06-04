using System;
using System.Collections.Generic;

#nullable disable

namespace SanGuseppeNuovoSito.Models
{
    public partial class RegistroAccessi
    {
        public int Id { get; set; }
        public DateTime? Data { get; set; }
        public string Username { get; set; }
        public string Pagina { get; set; }
        public string Note { get; set; }
        public string Ip { get; set; }
    }
}
