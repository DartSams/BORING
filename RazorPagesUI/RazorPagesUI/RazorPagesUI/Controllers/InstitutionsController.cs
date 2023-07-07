using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesUI.Data;

namespace RazorPagesUI.Controllers
{
    public class InstitutionsController : Controller
    {
        private readonly SurveyDbContext _context;

        public InstitutionsController(SurveyDbContext context)
        {
            _context = context;
        }

        // GET: Institutions
        public async Task<IActionResult> Index()
        {
              return _context.Institution != null ? 
                          View(await _context.Institution.ToListAsync()) :
                          Problem("Entity set 'SurveyDbContext.Institution'  is null.");
        }

        // GET: Institutions/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Institution == null)
            {
                return NotFound();
            }

            var institution = await _context.Institution
                .FirstOrDefaultAsync(m => m.Id == id);
            if (institution == null)
            {
                return NotFound();
            }

            return View(institution);
        }

        // GET: Institutions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Institutions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Institution institution)
        {
            if (ModelState.IsValid)
            {
                institution.Id = Guid.NewGuid();
                _context.Add(institution);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(institution);
        }

        // GET: Institutions/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Institution == null)
            {
                return NotFound();
            }

            var institution = await _context.Institution.FindAsync(id);
            if (institution == null)
            {
                return NotFound();
            }
            return View(institution);
        }

        // POST: Institutions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name")] Institution institution)
        {
            if (id != institution.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(institution);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InstitutionExists(institution.Id))
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
            return View(institution);
        }

        // GET: Institutions/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Institution == null)
            {
                return NotFound();
            }

            var institution = await _context.Institution
                .FirstOrDefaultAsync(m => m.Id == id);
            if (institution == null)
            {
                return NotFound();
            }

            return View(institution);
        }

        // POST: Institutions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Institution == null)
            {
                return Problem("Entity set 'SurveyDbContext.Institution'  is null.");
            }
            var institution = await _context.Institution.FindAsync(id);
            if (institution != null)
            {
                _context.Institution.Remove(institution);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InstitutionExists(Guid id)
        {
          return (_context.Institution?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
