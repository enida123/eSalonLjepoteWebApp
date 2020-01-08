using eStudioLjepote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eStudioLjepote.ViewModels
{
    public class UslugaListViewModel
    {
        public IEnumerable<Usluge> Usluge { get; set; }
        public VrstaUsluge vrsta { get; set; }
    }
}
