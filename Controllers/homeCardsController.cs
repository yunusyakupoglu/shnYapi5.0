using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using shnYapi5._0.Entity;
using shnYapi5._0.data;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using shnYapi5._0.Data;

namespace shnYapi5._0.Controllers
{
    public class homeCardsController : Controller
    {
        private readonly shnYapi5_0Context _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public homeCardsController(shnYapi5_0Context context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }

        // GET: homeCards
        public async Task<IActionResult> Index()
        {
            return View(await _context.homeCards.ToListAsync());
        }

        // GET: homeCards/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var homeCards = await _context.homeCards
                .FirstOrDefaultAsync(m => m.cardID == id);
            if (homeCards == null)
            {
                return NotFound();
            }

            return View(homeCards);
        }

        // GET: homeCards/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: homeCards/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormFile file, [Bind("cardID,baslik,aciklama,icerik,imgFile")] homeCards proje)
        {
            if (ModelState.IsValid)
            {
                //save image to wwwroot/image
                createImage(proje);

                //Insert record
                _context.Add(proje);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(proje);
        }

        public async void createImage(homeCards proje)
        {
            string wwwRootPath = _hostEnvironment.WebRootPath;
            string fileName = Path.GetFileNameWithoutExtension(proje.imgFile.FileName);
            string extension = Path.GetExtension(proje.imgFile.FileName);
            proje.imgYol = fileName = fileName + DateTime.Now.ToString("yymmssffff") + extension;
            //proje.imgYol = fileName = proje.imgFile.FileName;
            string path = Path.Combine(wwwRootPath + "/cardImg/", fileName);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                await proje.imgFile.CopyToAsync(fileStream);
            }
        }



        // GET: homeCards/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var homeCards = await _context.homeCards.FindAsync(id);
            if (homeCards == null)
            {
                return NotFound();
            }
            return View(homeCards);
        }

        // POST: homeCards/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("cardID,baslik,aciklama,icerik,imgFile")] homeCards proje, string fname)
        {
            if (id != proje.cardID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    string wwwRootPath = _hostEnvironment.WebRootPath;

                    string fileName = Path.GetFileNameWithoutExtension(proje.imgFile.FileName);
                    string extension = Path.GetExtension(proje.imgFile.FileName);
                    proje.imgYol = fileName = fileName + DateTime.Now.ToString("yymmssffff") + extension;
                    //proje.imgYol = fileName = proje.imgFile.FileName;
                    string path = Path.Combine(wwwRootPath + "/cardImg/", fileName);
                    proje.cardID = id;
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await proje.imgFile.CopyToAsync(fileStream);
                    }

                    var imgid = await _context.homeCards.FindAsync(id);
                    _context.homeCards.Remove(imgid);
                    fname = Path.Combine(wwwRootPath + "/cardImg/", fileName);
                    FileInfo fi = new FileInfo(fname);
                    if (fi.Exists)
                    {
                        System.IO.File.Delete(fname);
                        fi.Delete();
                    }

                    createImage(proje);

                    _context.Update(proje);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!homeCardsExists(proje.cardID))
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
            return View(proje);
        }

        // GET: homeCards/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var homeCards = await _context.homeCards
                .FirstOrDefaultAsync(m => m.cardID == id);
            if (homeCards == null)
            {
                return NotFound();
            }

            return View(homeCards);
        }

        // POST: homeCards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var homeCards = await _context.homeCards.FindAsync(id);
            _context.homeCards.Remove(homeCards);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool homeCardsExists(int id)
        {
            return _context.homeCards.Any(e => e.cardID == id);
        }
    }
}
