using Microsoft.AspNetCore.Mvc;
using News.Entities.Models;

namespace News.Web.Mvc.Controllers
{
    public class AuthController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(User user)
        {
            if (!string.IsNullOrEmpty(user.Email))
            {
                return RedirectToAction("Index","Category");
            }
            return RedirectToAction("Register","Auth");
        }
        public IActionResult Register()
        {
            return View();
        }
      
        public IActionResult ForgotPassword()
        {
            return View();
        }
    }
}
