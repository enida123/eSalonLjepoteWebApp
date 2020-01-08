using System;
using System.Collections.Generic;

namespace eStudioLjepote.Models
{
    public partial class TipUplate
    {
        public TipUplate()
        {
            Uplate = new HashSet<Uplate>();
        }

        public int Id { get; set; }
        public string Naziv { get; set; }

        public ICollection<Uplate> Uplate { get; set; }
    }
}
