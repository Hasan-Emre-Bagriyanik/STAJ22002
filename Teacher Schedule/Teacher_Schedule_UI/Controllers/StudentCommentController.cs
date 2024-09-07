using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using Teacher_Schedule_UI.Dtos.StudentCommentDtos;

namespace Teacher_Schedule_UI.Controllers
{
    public class StudentCommentController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public StudentCommentController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44386/api/StudentComment");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultStudentCommentDto>>(jsonData);
                return View(values);
            }
            return View();
        }

    }
}
