using eStudioLjepote.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eStudioLjepote.Helper
{
    public static class Autentifikacija
    {
        private const string LogiraniKorisnik = "logirani_korisnik";

        public static void SetLogiraniKorisnik(this HttpContext context, Klijent korisnik)
        {
            context.Session.Set(LogiraniKorisnik, korisnik);
        }


        public static Klijent GetLogiraniKorisnik(this HttpContext context)
        {
            Klijent korisnik = context.Session.Get<Klijent>(LogiraniKorisnik);

            return korisnik;
        }
    }
}

