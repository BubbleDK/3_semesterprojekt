using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCafeUCN.MVC.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using NetCafeUCN.MVC.Models.DTO;
using NetCafeUCN.MVC.Services;
using NetCafeUCN.MVC.Authentication;

namespace NetCafeUCN.MVC.Controllers
{
    /// <summary>
    ///  AccountController klasse, som nedarver fra Controller
    /// </summary>
    [AllowAnonymous]
    public class AccountController : Controller
    {
        readonly IUserProviderService _userProvider;
        /// <summary>
        /// AccountController constructor
        /// </summary>
        /// <param name="userProvider">userProvider af typen IUserProviderService</param>
        public AccountController(IUserProviderService userProvider) => _userProvider = userProvider;

        // GET: AccountController
        /// <summary>
        /// Login metode til at vise Login View.
        /// </summary>
        /// <returns>Returnere et ActionResult af login view</returns>
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// Login post metode, som logger dig ind hvis de givne oplysninger er korrekte.
        /// </summary>
        /// <param name="loginInfo">Henter data fra den indtastede form, og former det som LoginModel</param>
        /// <param name="returnUrl">Det URL link som man skal sendes videre til</param>
        /// <returns>Returnere et ActionResult eller view</returns>
        [HttpPost]
        public async Task<IActionResult> Login([FromForm] LoginModel loginInfo, [FromQuery] string returnUrl)
        {
            UserLoginDto? userLoginDto = _userProvider.GetHashByEmail(loginInfo.Email);
            if (userLoginDto != null)
            {
                if (BCryptTool.ValidatePassword(loginInfo.Password, userLoginDto.PasswordHash) == false)
                {
                    ViewBag.Error = "Oplysninger ikke korrekt";
                    RedirectToAction("Login");
                }
                else
                {
                    UserDto? user = _userProvider.GetUserByLogin(loginInfo.Email, userLoginDto.PasswordHash);

                    if (user != null) { await SignIn(user); }
                    if (string.IsNullOrEmpty(returnUrl)) { return RedirectToAction("Index", "Home"); }
                }
            }
            else
            {
                ViewBag.Error = "Oplysninger ikke korrekt";
                RedirectToAction("Login"); 
            }
            return View();
        }

        // Skal der skrives dokumentation til private metoder?
        private async Task SignIn(UserDto user)
        {
            var claims = new List<Claim>
        {
            new Claim("id", user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Name),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.MobilePhone, user.PhoneNo),
            new Claim(ClaimTypes.Role, user.Role.ToString())
        };
            
            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                #region often used options - to consider including in cookie
                //AllowRefresh = <bool>,
                // Refreshing the authentication session should be allowed.

                //ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                // The time at which the authentication ticket expires. A 
                // value set here overrides the ExpireTimeSpan option of 
                // CookieAuthenticationOptions set with AddCookie.

                //IsPersistent = true,
                // Whether the authentication session is persisted across 
                // multiple requests. When used with cookies, controls
                // whether the cookie's lifetime is absolute (matching the
                // lifetime of the authentication ticket) or session-based.

                //IssuedUtc = <DateTimeOffset>,
                // The time at which the authentication ticket was issued.

                //RedirectUri = <string>
                // The full path or absolute URI to be used as an http 
                // redirect response value. 
                #endregion
                
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity),
                authProperties);

            TempData["Message"] = $"You are logged in as {claimsIdentity.Name}";
        }

        /// <summary>
        /// LogOut metode, som logger dig ud og fjerner din authentication cookie.
        /// </summary>
        /// <returns>Returnere et ActionResult af den valgte side</returns>
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            TempData["Message"] = "You are now logged out.";
            return RedirectToAction("Index", "");
        }

        //displayed if an area is off-limits, based on an authenticated user's claims

        //public IActionResult AccessDenied() => View();

    }
}
