using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using RoleAuth.DataContext;
using RoleAuth.Models;
using System.Security.Claims;
using System.Security.Principal;

namespace RoleAuth.Controllers
{
    public class LoginController : Controller
    {
        private readonly RoleAuthDBContext _context;

        public LoginController(RoleAuthDBContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User u)
        {
            var result = _context.Users.Where(x => x.Name.Equals(u.Name) && x.Password.Equals(u.Password)).ToList();
            if (result.Count() != 0)
            {
                ClaimsIdentity identity = null;
                bool isAuthenticated = false;
                if (u.Name == "Admin" && u.Password == "passcode")
                {
  
                    identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, u.Name),
                    new Claim(ClaimTypes.Role, "Admin")
                }, CookieAuthenticationDefaults.AuthenticationScheme);

                    isAuthenticated = true;
                }

               else if (u.Name == "Super Admin" && u.Password == "password")
                {  
                    identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, u.Name),
                    new Claim(ClaimTypes.Role, "Super Admin")
                }, CookieAuthenticationDefaults.AuthenticationScheme);

                    isAuthenticated = true;
                }
                else 
                {
                    identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, "User"),
                    new Claim(ClaimTypes.Role, "User")
                }, CookieAuthenticationDefaults.AuthenticationScheme);

                    isAuthenticated = true;
                }

                if (isAuthenticated)
                {
                    var principal = new ClaimsPrincipal(identity);

                    var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                    return RedirectToAction("Index", "Home");
                }
            }
                return View("Login");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
