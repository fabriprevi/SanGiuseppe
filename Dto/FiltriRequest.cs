using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SanGiuseppe.Models;
using Microsoft.AspNetCore.Authorization;

namespace SanGiuseppe.Models.Dto
{
    public class FiltriRequest
    {
        public class SearchRequest
        {
            public string Value { get; set; }
            public bool Regex { get; set; }
        }
        public class ColumnRequest
        {
            public string Data { get; set; }
            public string Name { get; set; }
            public bool Searchable { get; set; }
            public bool Orderable { get; set; }
            public SearchRequest Search { get; set; }
        }

        public class OrderRequest
        {
            public int Column { get; set; }
            public string Dir { get; set; }
        }

        public List<ColumnRequest> Columns { get; set; }
        public List<OrderRequest> Order { get; set; }
        // Skiping number of Rows count  
        public int Start { get; set; } = 0;
        //Paging Size (10,20,50,100)  
        public int Length { get; set; } = 0;
        public int Draw { get; set; }
        public SearchRequest Search { get; set; }
    }




}
