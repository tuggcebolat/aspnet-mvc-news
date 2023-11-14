using Microsoft.AspNetCore.Mvc;

namespace News.Web.Mvc.Controllers
{
    public class AboutUsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
