using System;
using System.Collections.Generic;

namespace eStudioLjepote.Models
{
    public partial class Proizvods
    {
        public Proizvods()
        {
            ProizvodUsluga = new HashSet<ProizvodUsluga>();
        }

        public int ProizvodId { get; set; }
        public decimal Cijena { get; set; }
        public DateTime DatumKupovine { get; set; }
        public int KolicinaUskladiste { get; set; }
        public string Naziv { get; set; }
        public string Sifra { get; set; }
        public byte[] Slika { get; set; }
        public byte[] SlikaThumb { get; set; }
        public int VrstaProizvodaId { get; set; }

        public VrstaProizvoda VrstaProizvoda { get; set; }
        public ICollection<ProizvodUsluga> ProizvodUsluga { get; set; }
    }
}
