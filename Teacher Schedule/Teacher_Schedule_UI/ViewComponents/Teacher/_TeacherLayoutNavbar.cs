using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Teacher_Schedule_UI.Dtos.TeacherDtos;
using Teacher_Schedule_UI.Services;

namespace Teacher_Schedule_UI.ViewComponents.Teacher
{
    public class _TeacherLayoutNavbar : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILoginService _loginService;
        public _TeacherLayoutNavbar(IHttpClientFactory httpClientFactory, ILoginService loginService)
        {
            _httpClientFactory = httpClientFactory;
            _loginService = loginService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        { 

            var userIdString = _loginService.GetUserId;

            int userId;

            if (int.TryParse(userIdString, out userId))
            {
                // Sayısal değeri 1 azaltın
                var modifiedUserId = userId - 1;
                var client = _httpClientFactory.CreateClient();
                var responseMessage = await client.GetAsync($"https://localhost:44386/api/Teachers/{modifiedUserId}");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonData = await responseMessage.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<GetByIDTeacherDto>(jsonData);
                    return View(values);
                }
            }
            return View();
        }
    }
}
