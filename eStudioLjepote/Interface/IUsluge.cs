using eStudioLjepote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eStudioLjepote.Interface
{
    public interface IUsluge
    {
        IEnumerable<Usluge> Usluge { get; }
        Usluge GetUslugeById(int uslugaId);
        List<Usluge> GetRecommendedUsluge(int uslugaId);

    }
}
