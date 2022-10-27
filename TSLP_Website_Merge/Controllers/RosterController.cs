using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TSLP_Website_Merge.Models;
using TSLP_Website_Merge.Models.Domain;

namespace TSLP_Website_Merge.Controllers
{
    public class RosterController : Controller
    {
        private readonly DatabaseContext _context;

        public RosterController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: Roster
        public async Task<IActionResult> Index()
        {
              return View(await _context.roster.ToListAsync());
        }

        // GET: Roster/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.roster == null)
            {
                return NotFound();
            }

            var roster = await _context.roster
                .FirstOrDefaultAsync(m => m.Id == id);
            if (roster == null)
            {
                return NotFound();
            }

            return View(roster);
        }

        // GET: Roster/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Roster/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,check,sellerId,rosterDate")] Roster roster)
        {
            if (ModelState.IsValid)
            {
                _context.Add(roster);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(roster);
        }

        // GET: Roster/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.roster == null)
            {
                return NotFound();
            }

            var roster = await _context.roster.FindAsync(id);
            if (roster == null)
            {
                return NotFound();
            }
            return View(roster);
        }

        // POST: Roster/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,check,sellerId,rosterDate")] Roster roster)
        {
            if (id != roster.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roster);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RosterExists(roster.Id))
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
            return View(roster);
        }

        // GET: Roster/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.roster == null)
            {
                return NotFound();
            }

            var roster = await _context.roster
                .FirstOrDefaultAsync(m => m.Id == id);
            if (roster == null)
            {
                return NotFound();
            }

            return View(roster);
        }

        // POST: Roster/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.roster == null)
            {
                return Problem("Entity set 'ApplicationDbContext.roster'  is null.");
            }
            var roster = await _context.roster.FindAsync(id);
            if (roster != null)
            {
                _context.roster.Remove(roster);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RosterExists(int id)
        {
          return _context.roster.Any(e => e.Id == id);
        }
    }
}
