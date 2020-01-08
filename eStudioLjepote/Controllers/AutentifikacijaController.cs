using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using eStudioLjepote.Models;
using eStudioLjepote.Helper;
using eStudioLjepote.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace eStudioLjepote.Controllers
{
    public class AutentifikacijaController : Controller
    {
        private readonly _150023Context _db;

        public AutentifikacijaController(_150023Context db)
        {
            _db = db;
        }

        public static string GenerateSalt()
        {
            var buf = new byte[16];
            (new RNGCryptoServiceProvider()).GetBytes(buf);
            return Convert.ToBase64String(buf);
        }

        public static string GenerateHash(string salt, string password)
        {
            byte[] src = Convert.FromBase64String(salt);
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] dst = new byte[src.Length + bytes.Length];

            System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(dst);
            return Convert.ToBase64String(inArray);
        }

        public IActionResult Login()
        {
            return View(new LoginVM());
        }
        [HttpPost]
        public IActionResult Login(LoginVM input)
        {
            Klijent klijent = _db.Klijent
                .SingleOrDefault(x => x.Username == input.Username);

            if (klijent == null)
            {
                TempData["error_poruka"] = "pogrešan username ili password";
                return View("Login", input);
            }
            if (klijent != null)
            {
                var newHash = GenerateHash(klijent.PasswordSalt,input.Password);

                if (newHash != klijent.PaswordHash)
                {
                    TempData["error_poruka"] = "pogrešan username ili password";
                    return View("Login", input);
                }
            }
            HttpContext.SetLogiraniKorisnik(klijent);
            return Redirect("/Home/Index");




        }
        public IActionResult Registracija()
        {
            AutentifikacijaRegistracijaVM model = new AutentifikacijaRegistracijaVM();
            model.Gradovi = _db.Grad.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Naziv
            }).ToList();
            return View(model);
        }

        [HttpPost]
        public IActionResult Registracija(AutentifikacijaRegistracijaVM registracija)
        {
            Klijent klijent = new Klijent();

            klijent.Ime = registracija.Ime;
            klijent.Prezime = registracija.Prezime;
            klijent.BrojTelefona = registracija.BrojTelefona;
            klijent.PasswordSalt = GenerateSalt();
            klijent.PaswordHash = GenerateHash(klijent.PasswordSalt, registracija.Password);
            klijent.Spol = registracija.Spol;
            klijent.Email = registracija.Email;
            klijent.GradId = registracija.GradID;
            klijent.Username = registracija.KorisnickoIme;

            _db.Klijent.Add(klijent);
            _db.SaveChanges();
            return RedirectToAction("Login");
        }
        public IActionResult Odjava()
        {
            HttpContext.Session.Clear();
            return Redirect("/Home/Index");
        }
    }
    

}