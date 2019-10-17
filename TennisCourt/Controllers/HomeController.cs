using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TennisCourt.Models;
using Microsoft.Extensions.DependencyInjection;
using TennisCourt.Data;

namespace TennisCourt.Controllers
{

    public class HomeController : Controller
        
    {
        private readonly ApplicationDbContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;
        private Task<IdentityUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        public HomeController(ApplicationDbContext context, RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _roleManager = roleManager;
            _userManager = userManager;
        }
        [Authorize]
        public async Task<IActionResult> Index()
        {
            // will give member role to every new user.
            await GivememberRole();


            return View();
        
            
        }

        public IActionResult Allmembers()
        {
            
            List<string> userids = _context.UserRoles.Where(a => a.RoleId == "e942f9d2-1615-4be0-9f81-8813b0179570").Select(b => b.UserId).Distinct().ToList();
            //The first step: get all user id collection as userids based on role from db.UserRoles

            List<IdentityUser> listUsers = _context.Users.Where(a => userids.Any(c => c == a.Id)).ToList();
            //The second step: find all users collection  which 's Id is contained at userids ;
            

            return View("Allmembers", listUsers);


        }
       

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [Authorize]
        [HttpGet]
        // giving a member role to the new user 
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

            return RedirectToAction("index", "home");



        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
