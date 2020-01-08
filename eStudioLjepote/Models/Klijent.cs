using System;
using System.Collections.Generic;

namespace eStudioLjepote.Models
{
    public partial class Klijent
    {
        public Klijent()
        {
            Ratings = new HashSet<Ratings>();
            Rezervacija = new HashSet<Rezervacija>();
            RezervacijaEdukacije = new HashSet<RezervacijaEdukacije>();
        }

        public int Id { get; set; }
        public string BrojTelefona { get; set; }
        public string Email { get; set; }
        public int GradId { get; set; }
        public string Ime { get; set; }
        public string PasswordSalt { get; set; }
        public string PaswordHash { get; set; }
        public string Prezime { get; set; }
        public string Spol { get; set; }
        public string Username { get; set; }

        public Grad Grad { get; set; }
        public ICollection<Ratings> Ratings { get; set; }
        public ICollection<Rezervacija> Rezervacija { get; set; }
        public ICollection<RezervacijaEdukacije> RezervacijaEdukacije { get; set; }
    }
}
