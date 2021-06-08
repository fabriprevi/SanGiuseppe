using System;
using System.Collections.Generic;

#nullable disable

namespace SanGiuseppe.Models
{
    public partial class TabellaGruppetti
    {
        public TabellaGruppetti()
        {
            Visitor = new HashSet<Visitor>();
        }

        public int Id { get; set; }
        public string Gruppetto { get; set; }

        public virtual CapiGruppetto CapiGruppetto { get; set; }
        public virtual ICollection<Visitor> Visitor { get; set; }
    }
}
