using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace News.Web.Mvc.Controllers
{
    public class CategoryController : Controller
    {
       // [Authorize]

        public IActionResult Index()
        {
            Console.WriteLine("HelloWorld");
            return View();
        }
    }
}
