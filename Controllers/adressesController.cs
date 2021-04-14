using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using shnYapi5._0.Entity;
using shnYapi5._0.data;

namespace shnYapi5._0.Controllers
{
    public class adressesController : Controller
    {
        private readonly shnYapi5_0Context _context;

        public adressesController(shnYapi5_0Context context)
        {
            _context = context;
        }

        // GET: adresses
        public async Task<IActionResult> Index()
        {
            return View(await _context.adresses.ToListAsync());
        }

        // GET: adresses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adress = await _context.adresses
                .FirstOrDefaultAsync(m => m.adresID == id);
            if (adress == null)
            {
                return NotFound();
            }

            return View(adress);
        }

        // GET: adresses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: adresses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("adresID,mahalle,sokak,isYeri,No,ilce,sehir")] adress adress)
        {
            if (ModelState.IsValid)
            {
                _context.Add(adress);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(adress);
        }

        // GET: adresses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adress = await _context.adresses.FindAsync(id);
            if (adress == null)
            {
                return NotFound();
            }
            return View(adress);
        }

        // POST: adresses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("adresID,mahalle,sokak,isYeri,No,ilce,sehir")] adress adress)
        {
            if (id != adress.adresID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(adress);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!adressExists(adress.adresID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(adress);
        }

        // GET: adresses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adress = await _context.adresses
                .FirstOrDefaultAsync(m => m.adresID == id);
            if (adress == null)
            {
                return NotFound();
            }

            return View(adress);
        }

        // POST: adresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var adress = await _context.adresses.FindAsync(id);
            _context.adresses.Remove(adress);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool adressExists(int id)
        {
            return _context.adresses.Any(e => e.adresID == id);
        }
    }
}
