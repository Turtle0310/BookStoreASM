using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Final_Asm.Data;
using Final_Asm.Models;
using System.Configuration;

namespace Final_Asm.Controllers
{
    public class UploadFilesController : Controller
    {
        private readonly Final_AsmContext _context;

        public UploadFilesController(Final_AsmContext context)
        {
            _context = context;
        }

        // GET: UploadFiles
        public async Task<IActionResult> Index()
        {
              return _context.uploadFiles != null ? 
                          View(await _context.uploadFiles.ToListAsync()) :
                          Problem("Entity set 'Final_AsmContext.uploadFiles'  is null.");
        }

        // GET: UploadFiles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.uploadFiles == null)
            {
                return NotFound();
            }

            var uploadFile = await _context.uploadFiles
                .FirstOrDefaultAsync(m => m.ID == id);
            if (uploadFile == null)
            {
                return NotFound();
            }

            return View(uploadFile);
        }

        // GET: UploadFiles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UploadFiles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name")] UploadFile uploadFile)
        {
            if (ModelState.IsValid)
            {
                _context.Add(uploadFile);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(uploadFile);
        }

        // GET: UploadFiles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.uploadFiles == null)
            {
                return NotFound();
            }

            var uploadFile = await _context.uploadFiles.FindAsync(id);
            if (uploadFile == null)
            {
                return NotFound();
            }
            return View(uploadFile);
        }

        // POST: UploadFiles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name")] UploadFile uploadFile)
        {
            if (id != uploadFile.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(uploadFile);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UploadFileExists(uploadFile.ID))
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
            return View(uploadFile);
        }

        // GET: UploadFiles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.uploadFiles == null)
            {
                return NotFound();
            }

            var uploadFile = await _context.uploadFiles
                .FirstOrDefaultAsync(m => m.ID == id);
            if (uploadFile == null)
            {
                return NotFound();
            }

            return View(uploadFile);
        }

        // POST: UploadFiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.uploadFiles == null)
            {
                return Problem("Entity set 'Final_AsmContext.uploadFiles'  is null.");
            }
            var uploadFile = await _context.uploadFiles.FindAsync(id);
            if (uploadFile != null)
            {
                _context.uploadFiles.Remove(uploadFile);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Upload() 
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upload(UploadFile model) 
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            model.Name = model.FileName.FileName;
            string filePath = Path.Combine(path, model.Name);
            using(var stream = new FileStream(filePath,FileMode.Create))
            {
                model.FileName.CopyTo(stream);
            }
            return View(model);
        }
        private bool UploadFileExists(int id)
        {
          return (_context.uploadFiles?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
