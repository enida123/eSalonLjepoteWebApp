using eStudioLjepote.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eStudioLjepote.Components
{
    public class VrstaUslugeMenu:ViewComponent
    {
        private readonly IVrstaUsluge _vrstaUsluge;

        
        public VrstaUslugeMenu(IVrstaUsluge vrstaUsluge)
        {
            _vrstaUsluge = vrstaUsluge;
        }

        public IViewComponentResult Invoke()
        {
            var vrste = _vrstaUsluge.VrsteUsluge.OrderBy(p => p.Naziv);
            return View(vrste);
        }
    }
}
