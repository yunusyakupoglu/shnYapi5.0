using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using shnYapi5._0.data;
using shnYapi5._0.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using shnYapi5._0.Entity;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using shnYapi5._0.Data;
using shnYapi5._0.Models.ViewModel;
using System.Net.Mail;

namespace shnYapi5._0.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly shnYapi5_0Context _context;


        public HomeController(ILogger<HomeController> logger, shnYapi5_0Context context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            homePageViewModel homePage = new homePageViewModel();
            homePage.homeCards = _context.homeCards.ToList();
            homePage.projes = _context.projes.ToList();
            homePage.paragraphs = _context.homeParagraphs.ToList();
            return View(homePage);
        }

        public IActionResult Kurumsal()
        {
            kurumsalViewModel kurumsalView = new kurumsalViewModel();
            kurumsalView.vizyons = _context.vizyons.ToList();
            kurumsalView.vizyonLists = _context.vizyonLists.ToList();
            kurumsalView.misyonumuzs = _context.misyons.ToList();
            return View(kurumsalView);
        }
        public IActionResult Hizmetler()
        {
            return View();
        }

        public async Task<IActionResult> Projeler()
        {
            return View(await _context.projes.ToListAsync());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proje = await _context.projes
                .FirstOrDefaultAsync(m => m.projeID == id);
            if (proje == null)
            {
                return NotFound();
            }

            return View(proje);
        }

        public async Task<IActionResult> cardDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proje = await _context.homeCards
                .FirstOrDefaultAsync(m => m.cardID == id);
            if (proje == null)
            {
                return NotFound();
            }

            return View(proje);
        }


        public async Task<IActionResult> Iletisim()
        {
            contactViewModel contact = new contactViewModel();
            contact.maps = await _context.maps.ToListAsync();
            contact.adresses = await _context.adresses.ToListAsync();
            contact.mails = await _context.Mail.ToListAsync();
            contact.phones = await _context.phone.ToListAsync();
            return View(contact);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
