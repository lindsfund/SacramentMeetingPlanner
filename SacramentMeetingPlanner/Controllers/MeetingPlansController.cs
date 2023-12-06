﻿using System;
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
    public class MeetingPlansController : Controller
    {
        private readonly MeetingPlanContext _context;

        public MeetingPlansController(MeetingPlanContext context)
        {
            _context = context;
        }

        // GET: MeetingPlans
        public async Task<IActionResult> Index()
        {
            return View(await _context.MeetingPlan.ToListAsync());
        }

        // GET: MeetingPlans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meetingPlan = await _context.MeetingPlan
                .FirstOrDefaultAsync(m => m.Id == id);
            if (meetingPlan == null)
            {
                return NotFound();
            }

            return View(meetingPlan);
        }

        // GET: MeetingPlans/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MeetingPlans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MeetingDate,ConductingLeader,PresidingLeader,OpeningHymn,OpeningPrayer,Buisness,SacramentHymn,Speaker,MusicalNumber,ClosingHymn,ClosingPrayer")] MeetingPlan meetingPlan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(meetingPlan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(meetingPlan);
        }

        // GET: MeetingPlans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meetingPlan = await _context.MeetingPlan.FindAsync(id);
            if (meetingPlan == null)
            {
                return NotFound();
            }
            return View(meetingPlan);
        }

        // POST: MeetingPlans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MeetingDate,ConductingLeader,PresidingLeader,OpeningHymn,OpeningPrayer,Buisness,SacramentHymn,Speaker,MusicalNumber,ClosingHymn,ClosingPrayer")] MeetingPlan meetingPlan)
        {
            if (id != meetingPlan.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(meetingPlan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MeetingPlanExists(meetingPlan.Id))
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
            return View(meetingPlan);
        }

        // GET: MeetingPlans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meetingPlan = await _context.MeetingPlan
                .FirstOrDefaultAsync(m => m.Id == id);
            if (meetingPlan == null)
            {
                return NotFound();
            }

            return View(meetingPlan);
        }

        // POST: MeetingPlans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var meetingPlan = await _context.MeetingPlan.FindAsync(id);
            if (meetingPlan != null)
            {
                _context.MeetingPlan.Remove(meetingPlan);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MeetingPlanExists(int id)
        {
            return _context.MeetingPlan.Any(e => e.Id == id);
        }
    }
}
