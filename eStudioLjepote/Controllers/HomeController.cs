using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using eStudioLjepote.Models;
using eStudioLjepote.ViewModels;

namespace eStudioLjepote.Controllers
{
    public class HomeController : Controller
    {
        private readonly _150023Context _db;

        public HomeController(_150023Context db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<VrstaUsluge> vrsteUslugaPrve = _db.VrstaUsluge.Where(x=>x.Naziv== "SMINKANJE" || x.Naziv== "DEPILACIJA" || x.Naziv== "MASAŽE").ToList();
            IEnumerable<VrstaUsluge> vrsteUslugaDruge = _db.VrstaUsluge.Where(x => x.Naziv == "MANIKIR I PEDIKIR" || x.Naziv == "TRETMANI LICA" || x.Naziv == "FRIZERSKE USLUGE").ToList();

            UslugeListHomeVM model = new UslugeListHomeVM
            {
                PrveUsluge = vrsteUslugaPrve,
                DrugeUsluge=vrsteUslugaDruge
            };

            return View(model);
        }
        public IActionResult ContactUs()
        {
            return View();
        }


    }
}
