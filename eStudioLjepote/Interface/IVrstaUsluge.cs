using eStudioLjepote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eStudioLjepote.Interface
{
   public  interface IVrstaUsluge
    {
        IEnumerable<VrstaUsluge> VrsteUsluge { get; }
       VrstaUsluge GetVrstaUslugeById(int vrstaId);
    }
}
