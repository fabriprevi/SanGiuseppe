using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Diagnostics;
using System.Security.Claims;
using System.IO;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;
using SanGiuseppe.Models;
namespace SanGiuseppe.helpers
{
    public class Funzioni
    {
        private readonly SanGiuseppeContext _context;
        private readonly IHttpContextAccessor _contextAccessor;
        public Funzioni(SanGiuseppeContext context, IHttpContextAccessor contextAccessor)
        {
            _context = context;
            _contextAccessor = contextAccessor;
        }
        public string GetWord(string chiave)
        {
            
            var dizionario = _context.Dizionario.FirstOrDefault(a => a.Chiave == chiave && a.Lingua == ImpostaLingua());
            if (dizionario != null)
            {
                return dizionario.Traduzione;
            }
            return chiave;
        }

        public string ImpostaLingua()
        {
            var lingua = _contextAccessor.HttpContext.Request.Cookies["SanGiuseppeLingua"];
            if (lingua == "" || lingua == null) { lingua = "ITA"; }

            return lingua;
        }
    }
}
