using System;
using System.Collections.Generic;

namespace eStudioLjepote.Models
{
    public partial class Rezervacija
    {
        public Rezervacija()
        {
            PruzeneUsluge = new HashSet<PruzeneUsluge>();
            Uplate = new HashSet<Uplate>();
        }

        public int Id { get; set; }
        public int BrojOsoba { get; set; }
        public DateTime DatumRezervacije { get; set; }
        public int KlijentId { get; set; }
        public bool Otkazano { get; set; }
        public bool Prihvaceno { get; set; }
        public int UslugeId { get; set; }
        public string Vrijeme { get; set; }
        public string Status { get; set; }
        public string Napomena { get; set; }
        public Klijent Klijent { get; set; }
        public Usluge Usluge { get; set; }
        public ICollection<PruzeneUsluge> PruzeneUsluge { get; set; }
        public ICollection<Uplate> Uplate { get; set; }
    }
}
