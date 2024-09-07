using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Teacher_Schedule_UI.Dtos.TeacherDtos;

namespace Teacher_Schedule_UI.ViewComponents.HomePage
{
    public class _DefaultHomePageTeacherList:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _DefaultHomePageTeacherList(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44386/api/Teachers");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultTeachersDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
