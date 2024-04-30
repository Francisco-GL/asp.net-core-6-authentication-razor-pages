using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace WebApplication1.Pages
{
    public class LoginModel : PageModel
    {

		public class LoginUser
		{
			public string UserName { get; set; }
			public string Password { get; set; }
		}

		[BindProperty]
        public LoginUser UserCredential { get; set; }

        [BindProperty]
        public string email { get; set; }
        [BindProperty]
        public string password { get; set; }
        public void OnGet()
        {
        }


        public async Task<IActionResult> OnPostAsync() {
            if (UserCredential.UserName == "user@gmail.com" && UserCredential.Password == "Contrasena123") {
                List<Claim> claims = new List<Claim>() {
                    new Claim(ClaimTypes.NameIdentifier, UserCredential.UserName),
                    new Claim(ClaimTypes.Name, UserCredential.UserName)
                };
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims,
                    CookieAuthenticationDefaults.AuthenticationScheme
                );

                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                await HttpContext.SignInAsync(claimsPrincipal);
                return RedirectToPage("/Index");
            }
            ViewData["ValidateMessage"] = "Email or Password incorrect!";
            return Page();
        } 
    }
}
