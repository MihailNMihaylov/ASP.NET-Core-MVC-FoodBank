using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FoodBank.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using FoodBank.Web.Areas.Identity.Data;

namespace FoodBank.Web.Controllers
{
    public class HomeController : Controller
    {
        private FoodBankContext context;
        private RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<FoodBankUser> _userManager;

        public HomeController(FoodBankContext context, UserManager<FoodBankUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            this.context = context;
            this._userManager = userManager;
            this._roleManager = roleManager;
        }

        public IActionResult Index()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                return this.RedirectToAction("AuthorizedIndex");
            }
            return View();
        }

        [Authorize]
        public async Task<IActionResult> AuthorizedIndex()
        {
            //adds every registered user as a admin
            //if (this.context.Users.Count() == 0)
            //{
            //    await this._roleManager.CreateAsync(new IdentityRole("Admin"));
            //    var userInfo = await this._userManager.GetUserAsync(this.User);
            //    await this._userManager.AddToRoleAsync(userInfo, "Admin");
            //}
            //else
            //{
            //    await this._roleManager.CreateAsync(new IdentityRole("Customer"));
            //    var userInfo = await this._userManager.GetUserAsync(this.User);
            //    await this._userManager.AddToRoleAsync(userInfo, "Customer");
            //}
            
            return View("AuthorizedIndex");
        }

        public IActionResult AboutUs()
        {
            //this.User.
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
