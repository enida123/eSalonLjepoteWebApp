using System;
using System.Collections.Generic;

namespace eStudioLjepote.Models
{
    public partial class Uplate
    {
        public int Id { get; set; }
        public float Iznos { get; set; }
        public int RezervacijaId { get; set; }
        public int TipUplateId { get; set; }
        public int ZaposlenikId { get; set; }
        public DateTime DatumUplate { get; set; }
        public float Popust { get; set; }

        public Rezervacija Rezervacija { get; set; }
        public TipUplate TipUplate { get; set; }
        public Zaposlenik Zaposlenik { get; set; }
    }
}
