using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eStudioLjepote.Models;
using eStudioLjepote.Helper;
using eStudioLjepote.Interface;
using eStudioLjepote.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace eStudioLjepote.Controllers
{
    public class UslugeController : Controller
    {
        private readonly IUsluge _uslugaRepository;
        private readonly IVrstaUsluge _vrstaUslugaRepository;
        private readonly _150023Context _db;
        public UslugeController(IUsluge uslugaRepository, IVrstaUsluge vrstaUslugaRepository, _150023Context db)
        {
            _uslugaRepository = uslugaRepository;
            _vrstaUslugaRepository = vrstaUslugaRepository;
            _db = db;
        }

        public IActionResult Index(int vrstaId)
        {

            IEnumerable<Usluge> usluge;
            usluge = _uslugaRepository.Usluge.Where(x => x.VrstaUslugeId == vrstaId).ToList();
            VrstaUsluge _vrsta = _vrstaUslugaRepository.GetVrstaUslugeById(vrstaId);
            return View(new UslugaListViewModel
            {
                Usluge = usluge,
                vrsta = _vrsta
                
             
            });
        }
        public IActionResult Detalji(int uslugaId)
        {
            Klijent klijent = HttpContext.GetLogiraniKorisnik();
            Usluge _usluga = _uslugaRepository.GetUslugeById(uslugaId);
            List<Usluge> preporuceneUsluge = _uslugaRepository.GetRecommendedUsluge(uslugaId);
           List <Ratings> ocjena = null;
            if (klijent != null)
            {
                ocjena = _db.Ratings.Where(x => x.UslugeId == uslugaId && x.KlijentId == klijent.Id).ToList();
            }
            UslugeDetaljiViewModel uslugeDetalji = new UslugeDetaljiViewModel();
            uslugeDetalji.usluga = _usluga;
            if(ocjena!=null)
            {
                foreach(var x in ocjena)
                  uslugeDetalji.Ocjena = x.Rating1;
            }
            uslugeDetalji.PreporuceneUsluge = preporuceneUsluge;
            Rezervacija rezervacija = null;
            if (klijent != null)
            {
                rezervacija= _db.Rezervacija.Where(x => x.KlijentId == klijent.Id && x.UslugeId == uslugaId).FirstOrDefault();
            }
            if (rezervacija==null)
            {
                uslugeDetalji.dozvoljeno = false;
            }
            else
            {
                uslugeDetalji.dozvoljeno = true;
            }
            return View(uslugeDetalji);
           
            
        }
        public IActionResult SetRating(UslugeDetaljiViewModel detalji, int rating)
        {
            Klijent klijent = HttpContext.GetLogiraniKorisnik();
            Ratings ocjena = new Ratings();
            ocjena.KlijentId = klijent.Id;
            ocjena.Rating1 = rating;
            ocjena.UslugeId = detalji.usluga.Id;

            _db.Ratings.Add(ocjena);
            _db.SaveChanges();

            return Redirect("/Usluge/Detalji?uslugaId=" + detalji.usluga.Id);
        }
       
    }
}