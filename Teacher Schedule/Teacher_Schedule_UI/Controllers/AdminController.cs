using Microsoft.AspNetCore.Mvc;

namespace Teacher_Schedule_UI.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
