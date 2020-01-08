using System;
using System.Collections.Generic;

namespace eStudioLjepote.Models
{
    public partial class RezervacijaEdukacije
    {
        public int Id { get; set; }
        public int EdukacijaId { get; set; }
        public int KlijentId { get; set; }

        public Edukacija Edukacija { get; set; }
        public Klijent Klijent { get; set; }
    }
}
