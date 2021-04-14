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
    public class projesController : Controller
    {
        private readonly shnYapi5_0Context _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public projesController(shnYapi5_0Context context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }

        // GET: projes
        //[Authorize]
        public async Task<IActionResult> List()
        {
            return View(await _context.projes.ToListAsync());
        }

        // GET: projes/Details/5
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

        // GET: projes/Create
        public IActionResult Create()
        {
                return View();
        }

        // POST: projes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormFile file,[Bind("projeID,projeAdi,projeBasligi,imgFile,icerik")] proje proje)
        {
            if (ModelState.IsValid)
            {
                //save image to wwwroot/image
                createImage(proje);

                //Insert record
                _context.Add(proje);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(List));
            }
            return View(proje);
        }

        public async void createImage(proje proje)
        {
            string wwwRootPath = _hostEnvironment.WebRootPath;
            string fileName = Path.GetFileNameWithoutExtension(proje.imgFile.FileName);
            string extension = Path.GetExtension(proje.imgFile.FileName);
            proje.imgYol = fileName = fileName + DateTime.Now.ToString("yymmssffff") + extension;
            //proje.imgYol = fileName = proje.imgFile.FileName;
            string path = Path.Combine(wwwRootPath + "/resimler/", fileName);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                await proje.imgFile.CopyToAsync(fileStream);
            }
        }


        public void DeleteImage(string path)
        {
            System.IO.File.Delete(path);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projes = await _context.projes.FindAsync(id);
            if (projes == null)
            {
                return NotFound();
            }
            return View(projes);
        }

        // POST: homeCards/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("projeID,projeAdi,projeBasligi,imgFile,icerik")] proje proje, string fname)
        {
            if (id != proje.projeID)
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
                    string path = Path.Combine(wwwRootPath + "/resimler/", fileName);
                    proje.projeID = id;
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await proje.imgFile.CopyToAsync(fileStream);
                    }

                    var imgid = await _context.projes.FindAsync(id);
                    _context.projes.Remove(imgid);
                    fname = Path.Combine(wwwRootPath + "/resimler/", fileName);
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
                    if (!projeExists(proje.projeID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(List));
            }
            return View(proje);
        }

        // GET: projes/Delete/5
        public async Task<IActionResult> Delete(int? id)
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

        // POST: projes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var proje = await _context.projes.FindAsync(id);
            _context.projes.Remove(proje);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(List));
        }

        private bool projeExists(int id)
        {
            return _context.projes.Any(e => e.projeID == id);
        }
    }
}
