using System;
using System.Collections.Generic;

namespace eStudioLjepote.Models
{
    public partial class Zaposlenik
    {
        public Zaposlenik()
        {
            Edukacija = new HashSet<Edukacija>();
            Plata = new HashSet<Plata>();
            PruzeneUsluge = new HashSet<PruzeneUsluge>();
            Uplate = new HashSet<Uplate>();
            ZaposleniciUloge = new HashSet<ZaposleniciUloge>();
        }

        public int Id { get; set; }
        public string BrojTelefona { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public DateTime DatumZaposelenja { get; set; }
        public string Email { get; set; }
        public int GradId { get; set; }
        public string Ime { get; set; }
        public string Jmbg { get; set; }
        public string PasswordSalt { get; set; }
        public string PaswordHash { get; set; }
        public string Prezime { get; set; }
        public double? TekuciRacun { get; set; }
        public string Username { get; set; }

        public Grad Grad { get; set; }
        public ICollection<Edukacija> Edukacija { get; set; }
        public ICollection<Plata> Plata { get; set; }
        public ICollection<PruzeneUsluge> PruzeneUsluge { get; set; }
        public ICollection<Uplate> Uplate { get; set; }
        public ICollection<ZaposleniciUloge> ZaposleniciUloge { get; set; }
    }
}
