using Microsoft.AspNetCore.Mvc;

namespace News.Web.Mvc.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
