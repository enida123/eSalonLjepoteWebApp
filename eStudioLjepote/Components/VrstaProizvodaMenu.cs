using eStudioLjepote.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eStudioLjepote.Components
{
    public class VrstaProizvodaMenu:ViewComponent
    {
        private readonly IVrstaProizvoda vrstaProizvoda;

        public VrstaProizvodaMenu(IVrstaProizvoda vrstaProizvoda)
        {
            this.vrstaProizvoda = vrstaProizvoda;
        }
        public IViewComponentResult Invoke()
        {
            var vrste = vrstaProizvoda.VrsteProizvoda.OrderBy(p => p.Naziv);
            return View(vrste);
        }
    }
}
