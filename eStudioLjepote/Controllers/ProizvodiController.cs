using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eStudioLjepote.Models;
using eStudioLjepote.Interface;
using eStudioLjepote.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace eStudioLjepote.Controllers
{
    public class ProizvodiController : Controller
    {
        private readonly _150023Context _db;

        public ProizvodiController(_150023Context db)
        {
            _db = db;
            
        }

        public IActionResult Index(int vrstaId)
        {
            IEnumerable<Proizvods> proizvodi = _db.Proizvods.Where(x => x.VrstaProizvodaId == vrstaId).ToList();
            ProizvodiListVM model = new ProizvodiListVM
            {
                Proizvodi = proizvodi
            };

            return View(model);
        }
    }
}