using eStudioLjepote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eStudioLjepote.ViewModels
{
    public class UslugeDetaljiViewModel
    {
        public Usluge usluga { get; set; }
        public int Ocjena { get; set; }
        public List<Usluge> PreporuceneUsluge { get; set; }
        public bool dozvoljeno { get; set; }

    }
}
