using eStudioLjepote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eStudioLjepote.ViewModels
{
    public class UslugeListHomeVM
    {
        public IEnumerable<VrstaUsluge> PrveUsluge { get; set; }
        public IEnumerable<VrstaUsluge> DrugeUsluge { get;  set; }
    }
}
