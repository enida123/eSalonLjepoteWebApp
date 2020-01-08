using System;
using System.Collections.Generic;

namespace eStudioLjepote.Models
{
    public partial class ProizvodUsluga
    {
        public int ProizvodUslugaId { get; set; }
        public int ProizvodId { get; set; }
        public int UslugeId { get; set; }

        public Proizvods Proizvod { get; set; }
        public Usluge Usluge { get; set; }
    }
}
