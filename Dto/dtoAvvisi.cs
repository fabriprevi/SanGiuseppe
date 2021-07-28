using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

#nullable disable

namespace SanGiuseppe.Models.Dto
{
    public partial class dtoAvvisi
    {

        public int? Ordinamento { get; set; }
        public string Zona { get; set; }
        public string Titolo { get; set; }
        public string Contenuto { get; set; }
        public string Link { get; set; }
        public bool Visibile { get; set; }
        public DateTime Data { get; set; }
        public int Anno { get; set; }
        public string Lingua { get; set; }
        public string Categoria { get; set; }
        public string Colore { get; set; }

        public Guid UID { get; set; }

        public IFormFile attachment { get; set; }


    }
}
