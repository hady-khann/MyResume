using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyResume.Models;

namespace MyResume.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ExperiencesController : Controller
    {
        private readonly CardContext _context;

        public ExperiencesController(CardContext context)
        {
            _context = context;
        }

        // GET: Admin/Experiences
        public async Task<IActionResult> Index()
        {
            return View(await _context.Experiences.ToListAsync());
        }

        // GET: Admin/Experiences/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var experiences = await _context.Experiences
                .FirstOrDefaultAsync(m => m.Id == id);
            if (experiences == null)
            {
                return NotFound();
            }

            return View(experiences);
        }

        // GET: Admin/Experiences/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Experiences/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Explain1,Explain2")] Experiences experiences)
        {
            if (ModelState.IsValid)
            {
                _context.Add(experiences);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(experiences);
        }

        // GET: Admin/Experiences/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var experiences = await _context.Experiences.FindAsync(id);
            if (experiences == null)
            {
                return NotFound();
            }
            return View(experiences);
        }

        // POST: Admin/Experiences/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Explain1,Explain2")] Experiences experiences)
        {
            if (id != experiences.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(experiences);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExperiencesExists(experiences.Id))
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
            return View(experiences);
        }

        // GET: Admin/Experiences/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var experiences = await _context.Experiences
                .FirstOrDefaultAsync(m => m.Id == id);
            if (experiences == null)
            {
                return NotFound();
            }

            return View(experiences);
        }

        // POST: Admin/Experiences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var experiences = await _context.Experiences.FindAsync(id);
            _context.Experiences.Remove(experiences);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExperiencesExists(int id)
        {
            return _context.Experiences.Any(e => e.Id == id);
        }
    }
}
