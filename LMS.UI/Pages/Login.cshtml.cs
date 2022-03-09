using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LMS.UI.Pages
{
    public class LoginModel : PageModel
    {
        public async Task<IActionResult> OnGetAsync(string redirectUri)
        {
            Console.WriteLine("LoginModel");
            Console.WriteLine(redirectUri);
            if (string.IsNullOrWhiteSpace(redirectUri))
            {
                redirectUri = Url.Content("~/");
                
                Console.WriteLine("updated redirectUri");
                Console.WriteLine(redirectUri);
            }

            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction(redirectUri);
            }

            return Challenge(
                new AuthenticationProperties
                {
                    RedirectUri = redirectUri
                },
                OpenIdConnectDefaults.AuthenticationScheme);

        }
    }
}
