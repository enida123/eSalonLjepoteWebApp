using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using eStudioLjepote.Models;
using eStudioLjepote.Helper;

namespace eStudioLjepote.Controllers
{
    public class RatingsController : Controller
    {
        private readonly _150023Context _db;

        public RatingsController(_150023Context db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

    
    }
}