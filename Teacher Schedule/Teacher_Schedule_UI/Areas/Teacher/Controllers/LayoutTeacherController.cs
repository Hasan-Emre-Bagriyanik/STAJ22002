using Microsoft.AspNetCore.Mvc;

namespace Teacher_Schedule_UI.Areas.Teacher.Controllers
{
    [Area("Teacher")]
    public class LayoutTeacherController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
