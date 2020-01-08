using eStudioLjepote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eStudioLjepote.ViewModels
{
    public class EdukacijaListViewModel
    {
        public IEnumerable<Edukacija> Edukacija { get; set; }
        public bool dozvoljeno { get; set; }
    }
}
