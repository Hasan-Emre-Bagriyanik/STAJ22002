using Microsoft.AspNetCore.Mvc;

namespace Teacher_Schedule_UI.Controllers
{
    public class StatisticController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public StatisticController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {

            #region Statistics1
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44386/api/Statistics/LessonCount");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            ViewBag.lessonCount = jsonData;
            #endregion

            #region Statistics2
            var client2 = _httpClientFactory.CreateClient();
            var responseMessage2 = await client2.GetAsync("https://localhost:44386/api/Statistics/NumberOfProgrammeLessonsOnFriday");
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            ViewBag.NumberOfProgrammeLessonsOnFridayCount = jsonData2;
            #endregion

            #region Statistics3
            var client3 = _httpClientFactory.CreateClient();
            var responseMessage3 = await client3.GetAsync("https://localhost:44386/api/Statistics/NumberOfProgrammeLessonsOnMonday");
            var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
            ViewBag.NumberOfProgrammeLessonsOnMondayCount = jsonData3;
            #endregion

            #region Statistics4
            var client4 = _httpClientFactory.CreateClient();
            var responseMessage4 = await client4.GetAsync("https://localhost:44386/api/Statistics/NumberOfProgrammeLessonsOnThursday");
            var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
            ViewBag.NumberOfProgrammeLessonsOnThursdayCount = jsonData4;
            #endregion

            #region Statistics5
            var client5 = _httpClientFactory.CreateClient();
            var responseMessage5 = await client5.GetAsync("https://localhost:44386/api/Statistics/NumberOfProgrammeLessonsOnTuesday");
            var jsonData5 = await responseMessage5.Content.ReadAsStringAsync();
            ViewBag.NumberOfProgrammeLessonsOnTuesdayCount = jsonData5;
            #endregion

            #region Statistics6
            var client6 = _httpClientFactory.CreateClient();
            var responseMessage6 = await client6.GetAsync("https://localhost:44386/api/Statistics/NumberOfProgrammeLessonsOnWednesday");
            var jsonData6 = await responseMessage6.Content.ReadAsStringAsync();
            ViewBag.NumberOfProgrammeLessonsOnWednesdayCount = jsonData6;
            #endregion

            #region Statistics7
            var client7 = _httpClientFactory.CreateClient();
            var responseMessage7 = await client7.GetAsync("https://localhost:44386/api/Statistics/StudentCommentCount");
            var jsonData7 = await responseMessage7.Content.ReadAsStringAsync();
            ViewBag.StudentCommentCount = jsonData7;
            #endregion

            #region Statistics8
            var client8 = _httpClientFactory.CreateClient();
            var responseMessage8 = await client8.GetAsync("https://localhost:44386/api/Statistics/TeacherCount");
            var jsonData8 = await responseMessage8.Content.ReadAsStringAsync();
            ViewBag.TeacherCount = jsonData8;
            #endregion


            return View();
        }
    }
}
