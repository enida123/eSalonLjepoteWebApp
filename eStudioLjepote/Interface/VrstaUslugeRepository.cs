using eStudioLjepote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eStudioLjepote.Interface
{
    public class VrstaUslugeRepository:IVrstaUsluge
    {
        private readonly _150023Context _appDbContext;
        public VrstaUslugeRepository(_150023Context appDbContext)
        {
            _appDbContext = appDbContext;
        }


        public IEnumerable<VrstaUsluge> VrsteUsluge => _appDbContext.VrstaUsluge;

        public VrstaUsluge GetVrstaUslugeById(int vrstaId) => _appDbContext.VrstaUsluge.FirstOrDefault(p => p.Id == vrstaId);
    }
}
