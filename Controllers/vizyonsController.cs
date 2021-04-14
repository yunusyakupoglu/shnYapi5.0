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
    public class vizyonsController : Controller
    {
        private readonly shnYapi5_0Context _context;

        public vizyonsController(shnYapi5_0Context context)
        {
            _context = context;
        }

        // GET: vizyons
        public async Task<IActionResult> Index()
        {
            return View(await _context.vizyons.ToListAsync());
        }

        // GET: vizyons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vizyon = await _context.vizyons
                .FirstOrDefaultAsync(m => m.vizyonID == id);
            if (vizyon == null)
            {
                return NotFound();
            }

            return View(vizyon);
        }

        // GET: vizyons/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: vizyons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("vizyonID,title,arz,talep,content")] vizyon vizyon)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vizyon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vizyon);
        }

        // GET: vizyons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vizyon = await _context.vizyons.FindAsync(id);
            if (vizyon == null)
            {
                return NotFound();
            }
            return View(vizyon);
        }

        // POST: vizyons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("vizyonID,title,arz,talep,content")] vizyon vizyon)
        {
            if (id != vizyon.vizyonID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vizyon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!vizyonExists(vizyon.vizyonID))
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
            return View(vizyon);
        }

        // GET: vizyons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vizyon = await _context.vizyons
                .FirstOrDefaultAsync(m => m.vizyonID == id);
            if (vizyon == null)
            {
                return NotFound();
            }

            return View(vizyon);
        }

        // POST: vizyons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vizyon = await _context.vizyons.FindAsync(id);
            _context.vizyons.Remove(vizyon);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool vizyonExists(int id)
        {
            return _context.vizyons.Any(e => e.vizyonID == id);
        }
    }
}
