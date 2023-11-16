using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace News.Web.Mvc.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
