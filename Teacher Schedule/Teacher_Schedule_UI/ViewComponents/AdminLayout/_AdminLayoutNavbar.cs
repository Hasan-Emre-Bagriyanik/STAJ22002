using Microsoft.AspNetCore.Mvc;

namespace Teacher_Schedule_UI.ViewComponents.AdminLayout
{
    public class _AdminLayoutNavbar:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
