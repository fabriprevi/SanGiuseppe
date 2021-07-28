using System;
using System.Collections.Generic;

#nullable disable

namespace SanGiuseppe.Models
{
    public partial class Avvisi
    {
        public int Idavviso { get; set; }
        public int? Ordinamento { get; set; }
        public string Zona { get; set; }
        public string Titolo { get; set; }
        public string Contenuto { get; set; }
        public string Link { get; set; }
        public bool Visibile { get; set; }
        public int? Homepage { get; set; }
        public DateTime Data { get; set; }
        public int Anno { get; set; }
        public string Lingua { get; set; }
        public Guid UID { get; set; }
        public string Categoria { get; set; }
       public string Colore { get; set; }


        public virtual ICollection<AvvisiPermessi> AvvisiPermessi { get; set; }
    }
}
