using System;
using System.Collections.Generic;

namespace eStudioLjepote.Models
{
    public partial class Uloge
    {
        public Uloge()
        {
            ZaposleniciUloge = new HashSet<ZaposleniciUloge>();
        }

        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }

        public ICollection<ZaposleniciUloge> ZaposleniciUloge { get; set; }
    }
}
