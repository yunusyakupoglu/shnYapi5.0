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
    public class misyonumuzsController : Controller
    {
        private readonly shnYapi5_0Context _context;

        public misyonumuzsController(shnYapi5_0Context context)
        {
            _context = context;
        }

        // GET: misyonumuzs
        public async Task<IActionResult> Index()
        {
            return View(await _context.misyons.ToListAsync());
        }

        // GET: misyonumuzs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var misyonumuz = await _context.misyons
                .FirstOrDefaultAsync(m => m.misyonID == id);
            if (misyonumuz == null)
            {
                return NotFound();
            }

            return View(misyonumuz);
        }

        // GET: misyonumuzs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: misyonumuzs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("misyonID,title,content")] misyonumuz misyonumuz)
        {
            if (ModelState.IsValid)
            {
                _context.Add(misyonumuz);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(misyonumuz);
        }

        // GET: misyonumuzs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var misyonumuz = await _context.misyons.FindAsync(id);
            if (misyonumuz == null)
            {
                return NotFound();
            }
            return View(misyonumuz);
        }

        // POST: misyonumuzs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("misyonID,title,content")] misyonumuz misyonumuz)
        {
            if (id != misyonumuz.misyonID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(misyonumuz);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!misyonumuzExists(misyonumuz.misyonID))
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
            return View(misyonumuz);
        }

        // GET: misyonumuzs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var misyonumuz = await _context.misyons
                .FirstOrDefaultAsync(m => m.misyonID == id);
            if (misyonumuz == null)
            {
                return NotFound();
            }

            return View(misyonumuz);
        }

        // POST: misyonumuzs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var misyonumuz = await _context.misyons.FindAsync(id);
            _context.misyons.Remove(misyonumuz);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool misyonumuzExists(int id)
        {
            return _context.misyons.Any(e => e.misyonID == id);
        }
    }
}
