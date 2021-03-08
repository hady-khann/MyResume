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
    public class EducationsController : Controller
    {
        private readonly CardContext _context;

        public EducationsController(CardContext context)
        {
            _context = context;
        }

        // GET: Admin/Educations
        public async Task<IActionResult> Index()
        {
            return View(await _context.Educations.ToListAsync());
        }

        // GET: Admin/Educations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var educations = await _context.Educations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (educations == null)
            {
                return NotFound();
            }

            return View(educations);
        }

        // GET: Admin/Educations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Educations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Explain1,Explain2")] Educations educations)
        {
            if (ModelState.IsValid)
            {
                _context.Add(educations);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(educations);
        }

        // GET: Admin/Educations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var educations = await _context.Educations.FindAsync(id);
            if (educations == null)
            {
                return NotFound();
            }
            return View(educations);
        }

        // POST: Admin/Educations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Explain1,Explain2")] Educations educations)
        {
            if (id != educations.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(educations);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EducationsExists(educations.Id))
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
            return View(educations);
        }

        // GET: Admin/Educations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var educations = await _context.Educations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (educations == null)
            {
                return NotFound();
            }

            return View(educations);
        }

        // POST: Admin/Educations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var educations = await _context.Educations.FindAsync(id);
            _context.Educations.Remove(educations);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EducationsExists(int id)
        {
            return _context.Educations.Any(e => e.Id == id);
        }
    }
}
