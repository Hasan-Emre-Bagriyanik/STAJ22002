using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using Teacher_Schedule_UI.Dtos.LessonDtos;
using Teacher_Schedule_UI.Dtos.ScheduleDtos;
using Teacher_Schedule_UI.Dtos.TeacherDtos;

namespace Teacher_Schedule_UI.Controllers
{
    public class ScheduleController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ScheduleController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
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

        public async Task<IActionResult> ViewSchedule(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44386/api/Schedules/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<GetByIDScheduleDto>>(jsonData);
                return View(values);
            }
            return View();
        }


        public async Task<IActionResult> GenerateRandomSchedule(int id)
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                var responseMessage = await client.GetAsync($"https://localhost:44386/api/Lessons/GetByIDLessonBranch/{id}");

                if (!responseMessage.IsSuccessStatusCode)
                {
                    return Content("Dersler getirilemedi. Lütfen daha sonra tekrar deneyin.");
                }

                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var lessons = JsonConvert.DeserializeObject<List<GetByIDLessonDto>>(jsonData);

                if (lessons == null || !lessons.Any())
                {
                    return Content("Dersler alınamadı veya ders listesi boş. Lütfen daha sonra tekrar deneyin.");
                }

                var deleteResponse = await client.DeleteAsync($"https://localhost:44386/api/Schedules/DeleteByTeacherId/{id}");
                if (!deleteResponse.IsSuccessStatusCode)
                {
                    return Content("Mevcut program silinemedi. Lütfen daha sonra tekrar deneyin.");
                }

                var daysOfWeek = new[] { "Pazartesi", "Salı", "Çarşamba", "Perşembe", "Cuma" };
                var random = new Random();
                var selectedDays = daysOfWeek.OrderBy(x => random.Next()).Take(random.Next(3, 6)).ToList();
                if (!selectedDays.Any())
                {
                    return Content("Haftalık ders günleri oluşturulamadı. Lütfen tekrar deneyin.");
                }

                var newSchedules = new List<CreateScheduleDto>();

                foreach (var day in selectedDays)
                {
                    if (lessons.Count == 0)
                    {
                        return Content("Ders listesi boş. Program oluşturulamadı.");
                    }

                    var selectedLesson = lessons[random.Next(lessons.Count)];
                    var startTime = DateTime.Now.Date.AddDays(random.Next(0, 5)).AddHours(random.Next(8, 17));
                    var endTime = startTime.AddHours(1);

                    newSchedules.Add(new CreateScheduleDto
                    {
                        TeacherID = id,
                        LessonID = selectedLesson.LessonID,
                        DayOfWeek = day,
                        StartTime = startTime,
                        EndTime = endTime
                    });
                }

                foreach (var schedule in newSchedules)
                {
                    var jsonContent = new StringContent(JsonConvert.SerializeObject(schedule), Encoding.UTF8, "application/json");
                    var createResponse = await client.PostAsync("https://localhost:44386/api/Schedules/CreateSchedule", jsonContent);

                    if (!createResponse.IsSuccessStatusCode)
                    {
                        var statusCode = createResponse.StatusCode;
                        var errorMessage = await createResponse.Content.ReadAsStringAsync();
                        return Content($"Program oluşturulamadı. Hata Kodu: {statusCode}, Hata Mesajı: {errorMessage}");
                    }
                }

                return RedirectToAction("ViewSchedule", new { id = id });
            }
            catch (Exception ex)
            {
                return Content($"Bir hata oluştu: {ex.Message}");
            }
        }







    }
}
