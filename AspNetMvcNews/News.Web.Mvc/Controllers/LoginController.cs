using Microsoft.AspNetCore.Mvc;

namespace News.Web.Mvc.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
