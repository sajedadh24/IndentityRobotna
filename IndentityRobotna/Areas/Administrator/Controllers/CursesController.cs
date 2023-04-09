using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IndentityRobotna.Models;
using IndentityRobotna.Models.Data;

namespace IndentityRobotna.Controllers
{
    public class CursesController : Controller
    {
        private readonly AppDbContext _context;

        public CursesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Curses
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Curses.Include(c => c.Category);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Curses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var curse = await _context.Curses
                .Include(c => c.Category)
                .FirstOrDefaultAsync(m => m.CurseId == id);
            if (curse == null)
            {
                return NotFound();
            }

            return View(curse);
        }

        // GET: Curses/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId");
            return View();
        }

        // POST: Curses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CurseId,CurseName,Period,Cost,Img,CategoryId")] Curse curse)
        {
            if (ModelState.IsValid)
            {
                _context.Add(curse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", curse.CategoryId);
            return View(curse);
        }

        // GET: Curses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var curse = await _context.Curses.FindAsync(id);
            if (curse == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", curse.CategoryId);
            return View(curse);
        }

        // POST: Curses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CurseId,CurseName,Period,Cost,Img,CategoryId")] Curse curse)
        {
            if (id != curse.CurseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(curse);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CurseExists(curse.CurseId))
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
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", curse.CategoryId);
            return View(curse);
        }

        // GET: Curses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var curse = await _context.Curses
                .Include(c => c.Category)
                .FirstOrDefaultAsync(m => m.CurseId == id);
            if (curse == null)
            {
                return NotFound();
            }

            return View(curse);
        }

        // POST: Curses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var curse = await _context.Curses.FindAsync(id);
            _context.Curses.Remove(curse);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CurseExists(int id)
        {
            return _context.Curses.Any(e => e.CurseId == id);
        }
    }
}
