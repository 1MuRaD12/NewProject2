using Microsoft.AspNetCore.Mvc;

namespace project.Areas.adminpanel.Controllers
{
    public class HomeController : Controller
    {
        [Area("adminpanel")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
