using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace SanGiuseppe.Models
{
    public partial class UtentiPermessi
    {
        [Key]
        public int IdUtentePermesso {get;set;}
        public int Idutente { get; set; }
        public string Permesso { get; set; }

        public virtual Utenti Utenti { get; set; }

      
    
    }
}
