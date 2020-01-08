using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eStudioLjepote.Models;
using eStudioLjepote.Helper;
using eStudioLjepote.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;

namespace eStudioLjepote.Controllers
{
    public class RezervacijaController : Controller
    {
        private readonly _150023Context _db;

        public RezervacijaController(_150023Context db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            Klijent klijent = HttpContext.GetLogiraniKorisnik();

            IEnumerable<Rezervacija> rez = _db.Rezervacija.Where(x => x.KlijentId == klijent.Id).Include(u=>u.Usluge).Include(k=>k.Klijent).ToList();
            RezervacijeListViewModel model = new RezervacijeListViewModel
            {
                rezervacije = rez

            };

            return View(model);
        }
        public IActionResult Dodaj()
        {
            RezervacijaAddViewModel model = new RezervacijaAddViewModel
            {

                tipUsluge = _db.Usluge.Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Naziv
                }).ToList(),
                VrijemeList=new List<string>()
                {
                    "09:00",
                   
                    "09:30",
                    "10:00",
                    "10:30",
                    "11:00",
                    "11:30",
                    "12:00",
                    "12:30",
                    "13:00",
                    "13:30",
                    "14:00",
                    "14:30",
                    "15:00",
                    "15:30",
                }
            
            };
            return View(model);
        }
        public IActionResult Snimi(RezervacijaAddViewModel addViewModel)
        {
            Klijent klijent = HttpContext.GetLogiraniKorisnik();
           
            Rezervacija rezervacija = new Rezervacija
            {
                DatumRezervacije = addViewModel.DatumRezervacije,
                Vrijeme=addViewModel.Vrijeme,
                KlijentId=klijent.Id,
                UslugeId=addViewModel.UslugeId,
                BrojOsoba=addViewModel.BrojOsoba,
                Status="Na cekanju"
               

            };
            _db.Rezervacija.Add(rezervacija);
            _db.SaveChanges();
            return RedirectToAction("Index"); 
        }

        public IActionResult Otkazi(int Id)
        {
            Rezervacija rezervacija = _db.Rezervacija.Find(Id);
            rezervacija.Otkazano = true;
            rezervacija.Status = "Otkazana";

            _db.Rezervacija.Update(rezervacija);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}