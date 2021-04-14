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
    public class vizyonListsController : Controller
    {
        private readonly shnYapi5_0Context _context;

        public vizyonListsController(shnYapi5_0Context context)
        {
            _context = context;
        }

        // GET: vizyonLists
        public async Task<IActionResult> Index()
        {
            return View(await _context.vizyonLists.ToListAsync());
        }

        // GET: vizyonLists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vizyonList = await _context.vizyonLists
                .FirstOrDefaultAsync(m => m.vizyonListID == id);
            if (vizyonList == null)
            {
                return NotFound();
            }

            return View(vizyonList);
        }

        // GET: vizyonLists/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: vizyonLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("vizyonListID,content")] vizyonList vizyonList)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vizyonList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vizyonList);
        }

        // GET: vizyonLists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vizyonList = await _context.vizyonLists.FindAsync(id);
            if (vizyonList == null)
            {
                return NotFound();
            }
            return View(vizyonList);
        }

        // POST: vizyonLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("vizyonListID,content")] vizyonList vizyonList)
        {
            if (id != vizyonList.vizyonListID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vizyonList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!vizyonListExists(vizyonList.vizyonListID))
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
            return View(vizyonList);
        }

        // GET: vizyonLists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vizyonList = await _context.vizyonLists
                .FirstOrDefaultAsync(m => m.vizyonListID == id);
            if (vizyonList == null)
            {
                return NotFound();
            }

            return View(vizyonList);
        }

        // POST: vizyonLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vizyonList = await _context.vizyonLists.FindAsync(id);
            _context.vizyonLists.Remove(vizyonList);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool vizyonListExists(int id)
        {
            return _context.vizyonLists.Any(e => e.vizyonListID == id);
        }
    }
}
