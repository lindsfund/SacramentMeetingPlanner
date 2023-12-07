using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SacramentMeetingPlanner.Data;
using SacramentMeetingPlanner.Models;

namespace SacramentMeetingPlanner.Controllers
{
    public class MusicalNumbersController : Controller
    {
        private readonly MusicalNumbersContext _context;

        public MusicalNumbersController(MusicalNumbersContext context)
        {
            _context = context;
        }

        // GET: MusicalNumbers
        public async Task<IActionResult> Index()
        {
            return View(await _context.MusicalNumber.ToListAsync());
        }

        // GET: MusicalNumbers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var musicalNumber = await _context.MusicalNumber
                .FirstOrDefaultAsync(m => m.Id == id);
            if (musicalNumber == null)
            {
                return NotFound();
            }

            return View(musicalNumber);
        }

        // GET: MusicalNumbers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MusicalNumbers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Participant")] MusicalNumber musicalNumber)
        {
            if (ModelState.IsValid)
            {
                _context.Add(musicalNumber);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(musicalNumber);
        }

        // GET: MusicalNumbers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var musicalNumber = await _context.MusicalNumber.FindAsync(id);
            if (musicalNumber == null)
            {
                return NotFound();
            }
            return View(musicalNumber);
        }

        // POST: MusicalNumbers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Participant")] MusicalNumber musicalNumber)
        {
            if (id != musicalNumber.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(musicalNumber);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MusicalNumberExists(musicalNumber.Id))
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
            return View(musicalNumber);
        }

        // GET: MusicalNumbers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var musicalNumber = await _context.MusicalNumber
                .FirstOrDefaultAsync(m => m.Id == id);
            if (musicalNumber == null)
            {
                return NotFound();
            }

            return View(musicalNumber);
        }

        // POST: MusicalNumbers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var musicalNumber = await _context.MusicalNumber.FindAsync(id);
            if (musicalNumber != null)
            {
                _context.MusicalNumber.Remove(musicalNumber);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MusicalNumberExists(int id)
        {
            return _context.MusicalNumber.Any(e => e.Id == id);
        }
    }
}
