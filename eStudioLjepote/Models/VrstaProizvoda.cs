using System;
using System.Collections.Generic;

namespace eStudioLjepote.Models
{
    public partial class VrstaProizvoda
    {
        public VrstaProizvoda()
        {
            Proizvods = new HashSet<Proizvods>();
        }

        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public byte[] Slika { get; set; }

        public ICollection<Proizvods> Proizvods { get; set; }
    }
}
