using System;
using System.Collections.Generic;

namespace eStudioLjepote.Models
{
    public partial class Grad
    {
        public Grad()
        {
            Klijent = new HashSet<Klijent>();
            Zaposlenik = new HashSet<Zaposlenik>();
        }

        public int Id { get; set; }
        public int DrzavaId { get; set; }
        public string Naziv { get; set; }

        public Drzava Drzava { get; set; }
        public ICollection<Klijent> Klijent { get; set; }
        public ICollection<Zaposlenik> Zaposlenik { get; set; }
    }
}
