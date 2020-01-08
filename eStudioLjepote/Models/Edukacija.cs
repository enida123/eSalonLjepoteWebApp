using System;
using System.Collections.Generic;

namespace eStudioLjepote.Models
{
    public partial class Edukacija
    {
        public Edukacija()
        {
            RezervacijaEdukacije = new HashSet<RezervacijaEdukacije>();
        }

        public int Id { get; set; }
        public float Cijena { get; set; }
        public DateTime Kraj { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public DateTime Pocetak { get; set; }
        public int ZaposlenikId { get; set; }
        public int? BrojUcesnika { get; set; }
        public int? BrojPrijavljenih { get; set; }

        public Zaposlenik Zaposlenik { get; set; }
        public ICollection<RezervacijaEdukacije> RezervacijaEdukacije { get; set; }
    }
}
