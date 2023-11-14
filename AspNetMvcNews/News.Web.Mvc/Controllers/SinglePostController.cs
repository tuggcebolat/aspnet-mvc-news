using Microsoft.AspNetCore.Mvc;

namespace News.Web.Mvc.Controllers
{
    public class SinglePostController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
