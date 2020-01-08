using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eStudioLjepote.ViewModels
{
    public class RezervacijaAddViewModel
    {
       
        public int BrojOsoba { get; set; }
        public DateTime DatumRezervacije { get; set; }
        public int KlijentId { get; set; }
        public int UslugeId { get; set; }
        public string Vrijeme { get; set; }
        public List<SelectListItem> tipUsluge { get; set; }
        public List<string> VrijemeList { get; set; }


    }
}
