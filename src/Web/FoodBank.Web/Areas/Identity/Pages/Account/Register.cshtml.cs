using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using FoodBank.Web.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using FoodBank.Web.Models;
using System.Linq;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace FoodBank.Web.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<FoodBankUser> _signInManager;
        private readonly UserManager<FoodBankUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private FoodBankContext context;

        public RegisterModel(
            UserManager<FoodBankUser> userManager,
            SignInManager<FoodBankUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            FoodBankContext context)
        {
            this.context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            this._roleManager = roleManager;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public class InputModel
        {
            [Required]
            [Display(Name = "Nickname")]
            public string Nickname { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
        }

        public void OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            //returnUrl = returnUrl ?? Url.Content("~/");
            //if (ModelState.IsValid)
            //{             
            //    var user = new FoodBankUser() { UserName = Input.Nickname, Email = Input.Email };
            //    var result = await _userManager.CreateAsync(user, Input.Password);

            //    await _userManager.AddToRoleAsync(user, "Admin");

            //    if (result.Succeeded)
            //    {
            //        await _signInManager.SignInAsync(user, isPersistent: false);
            //        return LocalRedirect(returnUrl);
            //    }
            //}
            //return Page();

            returnUrl = returnUrl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                 await CreateRoles();
                var user = new FoodBankUser { UserName = Input.Nickname, Email = Input.Email };
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { userId = user.Id, code = code },
                        protocol: Request.Scheme);


                    await _signInManager.SignInAsync(user, isPersistent: false);
                    //TODO: register as admin if the user is the first one (NOT WORKING)
                    if (context.Users.Count() == 1)//not working
                    {
                        await _userManager.AddToRoleAsync(user, "Admin");
                    }
                    else
                    {
                        await _userManager.AddToRoleAsync(user, "Customer");
                    }
                    
                    return LocalRedirect(returnUrl);

                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }

        private async Task CreateRoles()
        {
            if (!await _roleManager.RoleExistsAsync("Admin"))
            {
                var adminRole = new IdentityRole("Admin");
                await _roleManager.CreateAsync(adminRole);

                var customerRole = new IdentityRole("Customer");
                await _roleManager.CreateAsync(customerRole);
            }
           
        }
    }
}
