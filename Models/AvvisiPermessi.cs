using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace SanGiuseppe.Models
{
    public partial class AvvisiPermessi
    {
        [Key]
        public int IdAvvisPermesso { get; set; }
        public int Idavviso { get; set; }
        public string Permesso { get; set; }

        public virtual Avvisi Avvisi {get;set;}

      
    }
}
