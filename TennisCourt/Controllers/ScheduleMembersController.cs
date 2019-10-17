using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TennisCourt.Data;
using TennisCourt.Models;

namespace TennisCourt.Controllers
{
    public class ScheduleMembersController : Controller
    {
        public List<int> schmem { get; set; }
        private readonly ApplicationDbContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;


        public ScheduleMembersController(ApplicationDbContext context, RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _roleManager = roleManager;
            _userManager = userManager;

        }

        // GET: ScheduleMembers
        public async Task<IActionResult> Index()
        {
          
            return View(await _context.ScheduleMembers.ToListAsync());
        }

        // GET: ScheduleMembers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scheduleMembers = await _context.ScheduleMembers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (scheduleMembers == null)
            {
                return NotFound();
            }

            return View(scheduleMembers);
        }

        // GET: ScheduleMembers/Create
        [Authorize(Roles="Member, Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: ScheduleMembers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ScheduleId,MemberEmail")] ScheduleMembers scheduleMembers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(scheduleMembers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(scheduleMembers);
        }

        // GET: ScheduleMembers/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scheduleMembers = await _context.ScheduleMembers.FindAsync(id);
            if (scheduleMembers == null)
            {
                return NotFound();
            }
            return View(scheduleMembers);
        }

        // POST: ScheduleMembers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ScheduleId,MemberEmail")] ScheduleMembers scheduleMembers)
        {
            if (id != scheduleMembers.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(scheduleMembers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ScheduleMembersExists(scheduleMembers.Id))
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
            return View(scheduleMembers);
        }

        // GET: ScheduleMembers/Delete/5
        [Authorize(Roles = "Admin, Member")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scheduleMembers = await _context.ScheduleMembers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (scheduleMembers == null)
            {
                return NotFound();
            }

            return View(scheduleMembers);
        }

        // POST: ScheduleMembers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var scheduleMembers = await _context.ScheduleMembers.FindAsync(id);
            _context.ScheduleMembers.Remove(scheduleMembers);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [Authorize]
        public ActionResult MySchedule()
        {
            var user = _userManager.GetUserName(User);
            var schedulemember = _context.ScheduleMembers
                .Where(m => m.MemberEmail == user);
           
            return View("MySchedule", schedulemember);
        }
        [Authorize]
        public ActionResult MyScheduleMember()
        {
            var user = _userManager.GetUserName(User);
            List<int> coachids = _context.Schedule.Where(a => a.CoachEmail == user).Select(b => b.Id).Distinct().ToList();
           

            List<ScheduleMembers> listUsers = _context.ScheduleMembers.Where(a => coachids.Any(c => a.ScheduleId == c)).ToList();

           
            return View("MyScheduleMember", listUsers);


        }


        private bool ScheduleMembersExists(int id)
        {
            return _context.ScheduleMembers.Any(e => e.Id == id);
        }
    }
}
