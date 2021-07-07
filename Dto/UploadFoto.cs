using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SanGiuseppe.Models.Dto
{
    public class UploadFoto
    {
        public IFormFile foto { get; set; }
    }
}
