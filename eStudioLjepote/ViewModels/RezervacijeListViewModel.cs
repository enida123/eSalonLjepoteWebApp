using eStudioLjepote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eStudioLjepote.ViewModels
{
    public class RezervacijeListViewModel
    {
        public IEnumerable<Rezervacija> rezervacije { get; set; }
    }
}
