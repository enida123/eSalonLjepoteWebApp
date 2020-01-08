using System;
using System.Collections.Generic;

namespace eStudioLjepote.Models
{
    public partial class Ratings
    {
        public int RatingId { get; set; }
        public int KlijentId { get; set; }
        public int Rating1 { get; set; }
        public int UslugeId { get; set; }

        public Klijent Klijent { get; set; }
        public Usluge Usluge { get; set; }
    }
}
