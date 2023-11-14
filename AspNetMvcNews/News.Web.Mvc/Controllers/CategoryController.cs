using Microsoft.AspNetCore.Mvc;

namespace News.Web.Mvc.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
