using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace CinemaApp.Web.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        private readonly SignInManager<IdentityUser> signInManager;

        public LoginModel(SignInManager<IdentityUser> signInManager)
        {
            this.signInManager = signInManager;
        }


        [BindProperty]
        public InputModel Input { get; set; } = default!;

        public string? ReturnUrl { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; } = default!;

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; } = default!;

            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }
        }

        public async Task<IActionResult> OnGetAsync(string? returnUrl = null)
        {
            if (!string.IsNullOrEmpty(returnUrl))
            {
                ModelState.AddModelError(string.Empty, "Invalid return URL.");
                
                return Page();
            }

            ReturnUrl = returnUrl ?? Url.Content("~/");

            if (signInManager.IsSignedIn(User))
            {
                return LocalRedirect(ReturnUrl);
            }

            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);
            await signInManager.SignOutAsync();

            ReturnUrl = returnUrl ?? Url.Content("~");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string? returnUrl = null)
        {
            ReturnUrl = returnUrl ?? Url.Content("~/");

            if (!ModelState.IsValid)
            {
                return Page();
            }

            SignInResult result = await signInManager.PasswordSignInAsync(Input.Email, Input.Password, Input.RememberMe, lockoutOnFailure: true);

            if (result.Succeeded)
            {
                return LocalRedirect(ReturnUrl);
            }

            if (result.IsLockedOut)
            {
                ModelState.AddModelError(string.Empty, $"User account {Input.Email} is locked out.");
                
                return Page();
            }

            ModelState.AddModelError(string.Empty, $"Invalid login attempt for user {Input.Email}.");
            
            return Page();
        }
    }
}
