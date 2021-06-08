using System;
using System.Collections.Generic;

#nullable disable

namespace SanGiuseppe.Models
{
    public partial class Menu
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public int? Gruppo { get; set; }
        public int? ParentId { get; set; }
        public int? Ordinamento { get; set; }
        public int? Visibile { get; set; }
        public string Link { get; set; }
        public string GruppoAccesso { get; set; }
    }
}
