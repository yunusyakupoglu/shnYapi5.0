using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using shnYapi5._0.Entity;
using shnYapi5._0.data;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace shnYapi5._0.Controllers
{
    public class AdminController : Controller
    {
        [Route("/admin")]
        public IActionResult girisYap()
        {
            return View();
        }

        //public async Task<IActionResult> GirisYap(admin m)
        //{
        //    return View();
        //}

    }
}
