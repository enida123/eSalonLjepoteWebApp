using eStudioLjepote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eStudioLjepote.Interface
{
    public interface IVrstaProizvoda
    {
        IEnumerable<VrstaProizvoda> VrsteProizvoda { get; }
        VrstaProizvoda GetVrstaProizvodaById(int vrstaId);
    }
}
