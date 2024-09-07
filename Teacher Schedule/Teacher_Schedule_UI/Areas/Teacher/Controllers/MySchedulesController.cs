using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Newtonsoft.Json;
using Teacher_Schedule_UI.Dtos.ScheduleDtos;
using Teacher_Schedule_UI.Services;

namespace Teacher_Schedule_UI.Areas.Teacher.Controllers
{
    [Area("Teacher")]
    public class MySchedulesController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILoginService _loginService;

        public MySchedulesController(IHttpClientFactory httpClientFactory, ILoginService loginService)
        {
            _httpClientFactory = httpClientFactory;
            _loginService = loginService;
        }

        public async Task<IActionResult> Index()
        {
            var id = _loginService.GetUserId;
            int userId;
            if (int.TryParse(id, out userId))
            {
                // Sayısal değeri 1 azaltın
                var modifiedUserId = userId - 1;

                var client = _httpClientFactory.CreateClient();
                var responseMessage = await client.GetAsync($"https://localhost:44386/api/Schedules/GetByIDScheduleByTeacher/{modifiedUserId}");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonData = await responseMessage.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<List<GetByIDScheduleDto>>(jsonData);
                    return View(values);
                }
            }

            return View();
        }
    }
}
