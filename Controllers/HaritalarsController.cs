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
    public class HaritalarsController : Controller
    {
        private readonly shnYapi5_0Context _context;

        public HaritalarsController(shnYapi5_0Context context)
        {
            _context = context;
        }

        // GET: Haritalars
        public async Task<IActionResult> Index()
        {
            return View(await _context.haritalars.ToListAsync());
        }

        // GET: Haritalars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var haritalar = await _context.haritalars
                .FirstOrDefaultAsync(m => m.haritaID == id);
            if (haritalar == null)
            {
                return NotFound();
            }

            return View(haritalar);
        }

        // GET: Haritalars/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Haritalars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("haritaID,Adres,x,y,aciklama")] Haritalar haritalar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(haritalar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(haritalar);
        }

        // GET: Haritalars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var haritalar = await _context.haritalars.FindAsync(id);
            if (haritalar == null)
            {
                return NotFound();
            }
            return View(haritalar);
        }

        // POST: Haritalars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("haritaID,Adres,x,y,aciklama")] Haritalar haritalar)
        {
            if (id != haritalar.haritaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(haritalar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HaritalarExists(haritalar.haritaID))
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
            return View(haritalar);
        }

        // GET: Haritalars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var haritalar = await _context.haritalars
                .FirstOrDefaultAsync(m => m.haritaID == id);
            if (haritalar == null)
            {
                return NotFound();
            }

            return View(haritalar);
        }

        // POST: Haritalars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var haritalar = await _context.haritalars.FindAsync(id);
            _context.haritalars.Remove(haritalar);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HaritalarExists(int id)
        {
            return _context.haritalars.Any(e => e.haritaID == id);
        }
    }
}
