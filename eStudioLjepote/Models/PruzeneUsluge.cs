using System;
using System.Collections.Generic;

namespace eStudioLjepote.Models
{
    public partial class PruzeneUsluge
    {
        public int Id { get; set; }
        public int RezervacijaId { get; set; }
        public int UslugaId { get; set; }
        public int ZaposlenikId { get; set; }

        public Rezervacija Rezervacija { get; set; }
        public Usluge Usluga { get; set; }
        public Zaposlenik Zaposlenik { get; set; }
    }
}
