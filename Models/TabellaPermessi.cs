using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace SanGiuseppe.Models
{
    public partial class TabellaPermessi
    {
        [Key]
        public string Permesso { get; set; }
    }
}
