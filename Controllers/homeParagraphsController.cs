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
    public class homeParagraphsController : Controller
    {
        private readonly shnYapi5_0Context _context;

        public homeParagraphsController(shnYapi5_0Context context)
        {
            _context = context;
        }

        // GET: homeParagraphs
        public async Task<IActionResult> Index()
        {
            return View(await _context.homeParagraphs.ToListAsync());
        }

        // GET: homeParagraphs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var homeParagraph = await _context.homeParagraphs
                .FirstOrDefaultAsync(m => m.paragraphID == id);
            if (homeParagraph == null)
            {
                return NotFound();
            }

            return View(homeParagraph);
        }

        // GET: homeParagraphs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: homeParagraphs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("paragraphID,title,section1,section2,section3")] homeParagraph homeParagraph)
        {
            if (ModelState.IsValid)
            {
                _context.Add(homeParagraph);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(homeParagraph);
        }

        // GET: homeParagraphs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var homeParagraph = await _context.homeParagraphs.FindAsync(id);
            if (homeParagraph == null)
            {
                return NotFound();
            }
            return View(homeParagraph);
        }

        // POST: homeParagraphs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("paragraphID,title,section1,section2,section3")] homeParagraph homeParagraph)
        {
            if (id != homeParagraph.paragraphID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(homeParagraph);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!homeParagraphExists(homeParagraph.paragraphID))
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
            return View(homeParagraph);
        }

        // GET: homeParagraphs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var homeParagraph = await _context.homeParagraphs
                .FirstOrDefaultAsync(m => m.paragraphID == id);
            if (homeParagraph == null)
            {
                return NotFound();
            }

            return View(homeParagraph);
        }

        // POST: homeParagraphs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var homeParagraph = await _context.homeParagraphs.FindAsync(id);
            _context.homeParagraphs.Remove(homeParagraph);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool homeParagraphExists(int id)
        {
            return _context.homeParagraphs.Any(e => e.paragraphID == id);
        }
    }
}
