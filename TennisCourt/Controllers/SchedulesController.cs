﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TennisCourt.Data;
using TennisCourt.Models;


namespace TennisCourt.Controllers
{
    
    public class SchedulesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;
        
        private Task<IdentityUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        public SchedulesController(ApplicationDbContext context, RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        // GET: Schedules
        [Authorize]
        public async Task<IActionResult> Index()
        {
            // this will remove the schedule from the table if the date is already gone.
            var time1 = DateTime.Now;
            foreach ( var x in _context.Schedule)
            {
                for (int i = 1; i <= x.Id; i++)
                {
                    if (i == x.Id)
                    {
                        var time2 = x.When;
                        int compare = DateTime.Compare(time1, time2);
                        if (compare > 0)
                        {
                            var deletedate = from date in _context.Schedule
                                             where date.Id == i
                                             select date;
                            foreach (var date in deletedate)
                            {
                                _context.Schedule.Remove(date);
                            }
                            try
                            {
                                await _context.SaveChangesAsync();
                            }
                            catch (Exception)
                            {

                            }

                        }    

                    }

                }

            }
           
            
            return View(await _context.Schedule.ToListAsync());
        }

        // GET: Schedules/Details/5
       
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schedule = await _context.Schedule
                .FirstOrDefaultAsync(m => m.Id == id);
            if (schedule == null)
            {
                return NotFound();
            }

            return View(schedule);
        }

        // GET: Schedules/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Schedules/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,When,Description,CoachEmail,Location")] Schedule schedule)
        {
            if (ModelState.IsValid)
            {
                _context.Add(schedule);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(schedule);
        }

        // GET: Schedules/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schedule = await _context.Schedule.FindAsync(id);
            if (schedule == null)
            {
                return NotFound();
            }
            return View(schedule);
        }

        // POST: Schedules/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,When,Description,CoachEmail,Location")] Schedule schedule)
        {
            if (id != schedule.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(schedule);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ScheduleExists(schedule.Id))
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
            return View(schedule);
        }

        // GET: Schedules/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schedule = await _context.Schedule
                .FirstOrDefaultAsync(m => m.Id == id);
            if (schedule == null)
            {
                return NotFound();
            }

            return View(schedule);
        }

        // POST: Schedules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var schedule = await _context.Schedule.FindAsync(id);
            _context.Schedule.Remove(schedule);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [Authorize]
        public ActionResult MySchedule()
        {
            var user = _userManager.GetUserName(User);
            var schedule = _context.Schedule
                .Where(m => m.CoachEmail == user);

            return View("MySchedule", schedule);
        }

        private bool ScheduleExists(int id)
        {
            return _context.Schedule.Any(e => e.Id == id);
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GivememberRole()
        {
            var user = await GetCurrentUserAsync();
            var userId = user?.Id;
            string mail = user?.Email;
            if ((User.IsInRole("Admin")) || (User.IsInRole("Coach")) || (User.IsInRole("Member")))
            {

            }
            else
            {
                var _userManager = HttpContext.RequestServices
                   .GetRequiredService<UserManager<IdentityUser>>();
                var signInManager = HttpContext.RequestServices
                    .GetRequiredService<SignInManager<IdentityUser>>();

                await _userManager.AddToRoleAsync(user, "Member");
                await signInManager.RefreshSignInAsync(user);

            }

            return RedirectToAction("about", "home");



        }
        [Authorize(Roles = "Member")]
        public async Task<IActionResult> Enrol(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var user = _userManager.GetUserName(User);
            var schedule = await _context.Schedule
                .FirstOrDefaultAsync(m => m.Id == id);

            if (schedule == null)
            {
                return NotFound();
            }


            return View(schedule);




        }

        // this wil enrol the schedule
        [HttpPost, ActionName("Enrol")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Enrolll([Bind("ScheduleId")] ScheduleMembers schedulemembers)
        {
            
            var user = _userManager.GetUserName(User);
            schedulemembers.MemberEmail = user;

            var schedule = await _context.Schedule
                .FirstOrDefaultAsync(m => m.Id == schedulemembers.ScheduleId);
          

            _context.Add(schedulemembers);

           


            if (schedule == null)
            {
                return NotFound();
            }

           
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

    }


}
