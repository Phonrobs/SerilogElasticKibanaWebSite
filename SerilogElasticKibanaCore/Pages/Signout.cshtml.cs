using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SerilogElasticKibanaCore.Pages
{
    public class SignoutModel : PageModel
    {
        public async Task OnGetAsync()
        {
            var username = User.Identity.Name;
            
            await HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);

            Serilog.Log.Information("{Event}: User '{username}' is signing out", "SIGNOUT", username);
        }
    }
}
