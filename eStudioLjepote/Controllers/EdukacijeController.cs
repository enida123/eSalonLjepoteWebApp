using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eStudioLjepote.Models;
using Microsoft.AspNetCore.Mvc;
using eStudioLjepote.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;
using eStudioLjepote.Helper;

namespace eStudioLjepote.Controllers
{
    public class EdukacijeController : Controller
    {
        private readonly _150023Context _db;

        public EdukacijeController(_150023Context db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Edukacija> edukacijas = _db.Edukacija.Include(x=>x.Zaposlenik).ToList();
        
            EdukacijaListViewModel model = new EdukacijaListViewModel
            {
                Edukacija = edukacijas,
                
            };
           
            return View(model);
        }
        public IActionResult Prijava(int Id)
        {
           
            
            Klijent klijent = HttpContext.GetLogiraniKorisnik();
            EdukacijaPrijava model = new EdukacijaPrijava();
            RezervacijaEdukacije rezEdukacije = _db.RezervacijaEdukacije.Where(x => x.KlijentId == klijent.Id && x.EdukacijaId==Id).FirstOrDefault();
            if(rezEdukacije != null)
            {
                model.poruka = "Već ste prijavljeni!";
                return View(model);
            }
            Edukacija edukacija = _db.Edukacija.Find(Id);
            ++(edukacija.BrojPrijavljenih);
            _db.Edukacija.Update(edukacija);
            _db.SaveChanges();
            if (edukacija.BrojPrijavljenih<=edukacija.BrojUcesnika)
            {
           
                RezervacijaEdukacije rezervacijaEdukacije = new RezervacijaEdukacije
                {
                    EdukacijaId = Id,
                    KlijentId = klijent.Id

                };
                _db.RezervacijaEdukacije.Add(rezervacijaEdukacije);
                _db.SaveChanges();
                model.poruka = "Uspjesno ste se prijavili na edukaciju!";

            }
            else
            {
                model.poruka = "Nazalost, broj mjesta je popunjen!";
            }

            return View(model);
        }
    }
}