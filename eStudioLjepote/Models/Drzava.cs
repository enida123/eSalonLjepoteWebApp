using System;
using System.Collections.Generic;

namespace eStudioLjepote.Models
{
    public partial class Drzava
    {
        public Drzava()
        {
            Grad = new HashSet<Grad>();
        }

        public int Id { get; set; }
        public string Naziv { get; set; }

        public ICollection<Grad> Grad { get; set; }
    }
}
