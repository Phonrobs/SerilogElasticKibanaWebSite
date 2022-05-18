using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace SerilogElasticKibanaCore.Pages
{
    public class SigninModel : PageModel
    {
        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public string ErrorMessage { get; set; }

        public void OnGet()
        {
        }

        public async Task OnPostAsync()
        {
            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
            {
                ErrorMessage = "Please input username and password!";
                return;
            }

            if (Username == "admin" && Password == "admin")
            {
                var claims = new List<Claim> {
                    new Claim(ClaimTypes.Name, Username)
                };

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = true
                };

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

                Serilog.Log.Information("{Event}: User '{username}' is signing in", "SIGNIN", Username);
                HttpContext.Response.Redirect("/Index");
            }
            else
            {
                ErrorMessage = "Invalid username or password";
                Serilog.Log.Error("{Event}: Invalid username or password for user '{username}'", "SIGNIN_ERROR", Username);
            }
        }
    }
}
