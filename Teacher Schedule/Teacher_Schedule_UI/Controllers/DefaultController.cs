using Microsoft.AspNetCore.Mvc;

namespace Teacher_Schedule_UI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
