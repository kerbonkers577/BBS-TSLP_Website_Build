﻿using System;
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
    public class ContentsController : Controller
    {
        private readonly DatabaseContext _context;

        public ContentsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: Contents
        public async Task<IActionResult> Index()
        {
              return View(await _context.content.ToListAsync());
        }

        // GET: Contents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.content == null)
            {
                return NotFound();
            }

            var content = await _context.content
                .FirstOrDefaultAsync(m => m.Id == id);
            if (content == null)
            {
                return NotFound();
            }

            return View(content);
        }

        // GET: Contents/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Contents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,title,description")] Content content)
        {
            if (ModelState.IsValid)
            {
                _context.Add(content);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(content);
        }

        // GET: Contents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.content == null)
            {
                return NotFound();
            }

            var content = await _context.content.FindAsync(id);
            if (content == null)
            {
                return NotFound();
            }
            return View(content);
        }

        // POST: Contents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,title,description")] Content content)
        {
            if (id != content.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(content);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContentExists(content.Id))
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
            return View(content);
        }

        // GET: Contents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.content == null)
            {
                return NotFound();
            }

            var content = await _context.content
                .FirstOrDefaultAsync(m => m.Id == id);
            if (content == null)
            {
                return NotFound();
            }

            return View(content);
        }

        // POST: Contents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.content == null)
            {
                return Problem("Entity set 'ApplicationDbContext.content'  is null.");
            }
            var content = await _context.content.FindAsync(id);
            if (content != null)
            {
                _context.content.Remove(content);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContentExists(int id)
        {
          return _context.content.Any(e => e.Id == id);
        }
    }
}
