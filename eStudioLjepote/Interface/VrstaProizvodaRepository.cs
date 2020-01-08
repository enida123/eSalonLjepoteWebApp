using eStudioLjepote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eStudioLjepote.Interface
{
    public class VrstaProizvodaRepository: IVrstaProizvoda
    {
        private readonly _150023Context _appDbContext;
        public VrstaProizvodaRepository(_150023Context appDbContext)
        {
            _appDbContext = appDbContext;
        }


        public IEnumerable<VrstaProizvoda> VrsteProizvoda => _appDbContext.VrstaProizvoda;

        public VrstaProizvoda GetVrstaProizvodaById(int vrstaId) => _appDbContext.VrstaProizvoda.FirstOrDefault(p => p.Id == vrstaId);
    }
}
