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
    public class phonesController : Controller
    {
        private readonly shnYapi5_0Context _context;

        public phonesController(shnYapi5_0Context context)
        {
            _context = context;
        }

        // GET: phones
        public async Task<IActionResult> Index()
        {
            return View(await _context.phone.ToListAsync());
        }

        // GET: phones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phone = await _context.phone
                .FirstOrDefaultAsync(m => m.phoneID == id);
            if (phone == null)
            {
                return NotFound();
            }

            return View(phone);
        }

        // GET: phones/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: phones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("phoneID,phoneNumber")] phone phone)
        {
            if (ModelState.IsValid)
            {
                _context.Add(phone);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(phone);
        }

        // GET: phones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phone = await _context.phone.FindAsync(id);
            if (phone == null)
            {
                return NotFound();
            }
            return View(phone);
        }

        // POST: phones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("phoneID,phoneNumber")] phone phone)
        {
            if (id != phone.phoneID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(phone);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!phoneExists(phone.phoneID))
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
            return View(phone);
        }

        // GET: phones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phone = await _context.phone
                .FirstOrDefaultAsync(m => m.phoneID == id);
            if (phone == null)
            {
                return NotFound();
            }

            return View(phone);
        }

        // POST: phones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var phone = await _context.phone.FindAsync(id);
            _context.phone.Remove(phone);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool phoneExists(int id)
        {
            return _context.phone.Any(e => e.phoneID == id);
        }
    }
}
