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
    public class mapsController : Controller
    {
        private readonly shnYapi5_0Context _context;

        public mapsController(shnYapi5_0Context context)
        {
            _context = context;
        }

        // GET: maps
        public async Task<IActionResult> Index()
        {
            return View(await _context.maps.ToListAsync());
        }

        // GET: maps/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var maps = await _context.maps
                .FirstOrDefaultAsync(m => m.mapID == id);
            if (maps == null)
            {
                return NotFound();
            }

            return View(maps);
        }

        // GET: maps/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: maps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("mapID,stringURL")] maps maps)
        {
            if (ModelState.IsValid)
            {
                _context.Add(maps);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(maps);
        }

        // GET: maps/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var maps = await _context.maps.FindAsync(id);
            if (maps == null)
            {
                return NotFound();
            }
            return View(maps);
        }

        // POST: maps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("mapID,stringURL")] maps maps)
        {
            if (id != maps.mapID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(maps);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!mapsExists(maps.mapID))
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
            return View(maps);
        }

        // GET: maps/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var maps = await _context.maps
                .FirstOrDefaultAsync(m => m.mapID == id);
            if (maps == null)
            {
                return NotFound();
            }

            return View(maps);
        }

        // POST: maps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var maps = await _context.maps.FindAsync(id);
            _context.maps.Remove(maps);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool mapsExists(int id)
        {
            return _context.maps.Any(e => e.mapID == id);
        }
    }
}
