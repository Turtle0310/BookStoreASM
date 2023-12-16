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
    public class OwnerAccsController : Controller
    {
        private readonly Final_AsmContext _context;

        public OwnerAccsController(Final_AsmContext context)
        {
            _context = context;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(OwnerAcc OA)
        {
            if (ModelState.IsValid)
            {
                Console.WriteLine(OA.Account);
                var User = _context.bookAccs.Where(x => x.Account.Equals(OA.Account) && x.Password.Equals(OA.Password)).FirstOrDefault();
                
                if (User != null)
                {
                    //var check = _context.bookAccs.Find(User);
                    
                    return RedirectToAction("Index", $"BookOwners",new {id = User.Id });
                }
                else
                {
                    return View();
                }

            }
            return View();
        }
        // GET: OwnerAccs
        public async Task<IActionResult> Index()
        {
              return _context.bookAccs != null ? 
                          View(await _context.bookAccs.ToListAsync()) :
                          Problem("Entity set 'Final_AsmContext.bookAccs'  is null.");
        }

        // GET: OwnerAccs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.bookAccs == null)
            {
                return NotFound();
            }

            var ownerAcc = await _context.bookAccs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ownerAcc == null)
            {
                return NotFound();
            }

            return View(ownerAcc);
        }

        // GET: OwnerAccs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OwnerAccs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(OwnerAcc ownerAcc)
        {
            if (ModelState.IsValid)
            {
                var check = _context.bookAccs.Where(x=>x.Account.Equals(ownerAcc.Account));
                if (check != null) 
                {
                    _context.Add(ownerAcc);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(ownerAcc);
            }
            return View(ownerAcc);
        }

        // GET: OwnerAccs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.bookAccs == null)
            {
                return NotFound();
            }

            var ownerAcc = await _context.bookAccs.FindAsync(id);
            if (ownerAcc == null)
            {
                return NotFound();
            }
            return View(ownerAcc);
        }

        // POST: OwnerAccs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Account,Password")] OwnerAcc ownerAcc)
        {
            if (id != ownerAcc.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ownerAcc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OwnerAccExists(ownerAcc.Id))
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
            return View(ownerAcc);
        }

        // GET: OwnerAccs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.bookAccs == null)
            {
                return NotFound();
            }

            var ownerAcc = await _context.bookAccs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ownerAcc == null)
            {
                return NotFound();
            }

            return View(ownerAcc);
        }

        // POST: OwnerAccs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.bookAccs == null)
            {
                return Problem("Entity set 'Final_AsmContext.bookAccs'  is null.");
            }
            var ownerAcc = await _context.bookAccs.FindAsync(id);
            if (ownerAcc != null)
            {
                _context.bookAccs.Remove(ownerAcc);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OwnerAccExists(int id)
        {
          return (_context.bookAccs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
