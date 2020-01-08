using System;
using System.Collections.Generic;

namespace eStudioLjepote.Models
{
    public partial class VrstaUsluge
    {
        public VrstaUsluge()
        {
            Usluge = new HashSet<Usluge>();
        }

        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public byte[] Slika { get; set; }

        public ICollection<Usluge> Usluge { get; set; }
    }
}
