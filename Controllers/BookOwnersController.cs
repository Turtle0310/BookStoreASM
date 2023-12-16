using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Final_Asm.Data;
using Final_Asm.Models;

namespace Final_Asm.Controllers
{
    public class BookOwnersController : Controller
    {
        private readonly Final_AsmContext _context;

        public BookOwnersController(Final_AsmContext context)
        {
            _context = context;
        }

        // GET: BookOwners
        public async Task<IActionResult> Index(int? id)
        {
            if (id == null || _context.bookOwners == null)
            {
                return NotFound();
            }
            ViewBag.Id = id;
            var final_AsmContext = _context.bookOwners.Include(b => b.OwnerAcc).Where(m => m.Id == id);
            return View(await final_AsmContext.ToListAsync());
        }
        public async Task<IActionResult> ViewBook(int? id)
        {
            if (id == null || _context.bookOwners == null)
            {
                return NotFound();
            }
            ViewBag.Id = id;
            var final_AsmContext = _context.books.Include(b => b.Author).Include(b => b.BookOwner).Include(b => b.Category).Where(m =>m.ID_BookOwner ==id);
            return View(await final_AsmContext.ToListAsync());
        }
        // GET: BookOwners/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.bookOwners == null)
            {
                return NotFound();
            }

            var bookOwner = await _context.bookOwners
                .Include(b => b.OwnerAcc)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bookOwner == null)
            {
                return NotFound();
            }
            ViewBag.ID = id;

            return View(bookOwner);
        }

        // GET: BookOwners/Create
        public IActionResult Create(int? id)
        {
            if (id == null || _context.bookOwners == null)
            {
                return NotFound();
            }
            ViewData["Id"] = new SelectList(_context.bookAccs, "Id", "Account");
            return View();
        }

        // POST: BookOwners/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NameStore")] BookOwner bookOwner)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookOwner);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", $"BookOwners", new { id = bookOwner.Id });
            }
            ViewData["Id"] = new SelectList(_context.bookAccs, "Id", "Account", bookOwner.Id);
            return View(bookOwner);
        }

        // GET: BookOwners/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.bookOwners == null)
            {
                return NotFound();
            }

            var bookOwner = await _context.bookOwners.FindAsync(id);
            if (bookOwner == null)
            {
                return NotFound();
            }
            ViewBag.ID = id;

            ViewData["Id"] = new SelectList(_context.bookAccs, "Id", "Account", bookOwner.Id);
            return View(bookOwner);
        }

        // POST: BookOwners/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NameStore")] BookOwner bookOwner)
        {
            if (id != bookOwner.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookOwner);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookOwnerExists(bookOwner.Id))
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
            ViewData["Id"] = new SelectList(_context.bookAccs, "Id", "Account", bookOwner.Id);
            return View(bookOwner);
        }

        // GET: BookOwners/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.bookOwners == null)
            {
                return NotFound();
            }

            var bookOwner = await _context.bookOwners
                .Include(b => b.OwnerAcc)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bookOwner == null)
            {
                return NotFound();
            }

            return View(bookOwner);
        }

        // POST: BookOwners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.bookOwners == null)
            {
                return Problem("Entity set 'Final_AsmContext.bookOwners'  is null.");
            }
            var bookOwner = await _context.bookOwners.FindAsync(id);
            if (bookOwner != null)
            {
                _context.bookOwners.Remove(bookOwner);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookOwnerExists(int id)
        {
          return (_context.bookOwners?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
