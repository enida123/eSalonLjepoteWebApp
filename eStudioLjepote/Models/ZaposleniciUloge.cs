using System;
using System.Collections.Generic;

namespace eStudioLjepote.Models
{
    public partial class ZaposleniciUloge
    {
        public int Id { get; set; }
        public int UlogaId { get; set; }
        public int ZaposlenikId { get; set; }

        public Uloge Uloga { get; set; }
        public Zaposlenik Zaposlenik { get; set; }
    }
}
