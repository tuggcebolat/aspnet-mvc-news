using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NETCore.Encrypt.Extensions;
using News.DAL.Contexts;
using News.Entities.Models;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Security.Cryptography.Xml;

namespace News.Web.Mvc.Controllers
{
    [Authorize]
    public class AuthController : Controller
    {
        //
        private readonly NewsDbContext _newsDbContext;
        private readonly IConfiguration _configuration;

        public AuthController(NewsDbContext newsDbContext, IConfiguration configuration)
        {
            _newsDbContext = newsDbContext;
            _configuration = configuration;
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login(User model)
        {
            if (ModelState.IsValid)
            {
                string md5Salt = _configuration.GetValue<string>("AppSettings:MD5Salt");
                string saltedPassword = model.Password + md5Salt; 
                string hashedPassword = saltedPassword.MD5();
                User user = _newsDbContext.Users.SingleOrDefault(x => x.Name.ToLower() == model.Name.ToLower() && x.Password == hashedPassword);
                if (user!=null)
                {
                    if (user.IsActive)
        {
                        ModelState.AddModelError(nameof(model.Name), "User is locked.");
                        return View(model);
                    }
                    List<Claim> claims = new List<Claim>();
                    claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
                    claims.Add(new Claim("UserName", user.Name));  //hak rol tanımı

                    ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,principal);
                }
                else
            {
                    ModelState.AddModelError("", "Username or password is incorrect.");
                    View(model);
                }
            }
            //if (!string.IsNullOrEmpty(user.Email))
            //{
            //    return RedirectToAction("Index","Category");
            //}
            return RedirectToAction("Register","Auth");
        }
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Register(RegisterViewModels models)
        {
            if (ModelState.IsValid)
            {
                if (_newsDbContext.Users.Any(x => x.Name == models.UserName.ToLower()))
                {
                    ModelState.AddModelError(nameof(models.UserName),"Username is already exists.");
                    View(models);
      
                }
                string md5Salt = _configuration.GetValue<string>("AppSettings:MD5Salt");
                string saltedPassword = models.Password + md5Salt; //string birleştirme yaptık. Login olurkende bunu kullanacağız.
                string hashedPassword = saltedPassword.MD5();  //hashedPasswordu , password yerine yazacagız.
                User user = new()
                {
                   Name= models.UserName,
                   Password= hashedPassword , //<=yerine yazdık.//=>//models.Password,
                   City="",
                   Email="",
                   
                };
                _newsDbContext.Users.Add(user);
                int affectedRowCount = _newsDbContext.SaveChanges();
                if (affectedRowCount == 0)
                {
                    ModelState.AddModelError("", "User can not be added.");
                }
                else
                {
                    return RedirectToAction("Login", "Auth");
                }
            }
            return RedirectToAction("Index", "Category");
            //return View(models);
        }
      
        public IActionResult ForgotPassword()
        {
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(nameof(Login));
        }
    }
}
