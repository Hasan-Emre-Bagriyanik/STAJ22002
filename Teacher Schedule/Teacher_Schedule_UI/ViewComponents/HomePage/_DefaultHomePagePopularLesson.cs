﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Teacher_Schedule_UI.Dtos.LessonDtos;

namespace Teacher_Schedule_UI.ViewComponents.HomePage
{
    public class _DefaultHomePagePopularLesson:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _DefaultHomePagePopularLesson(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44386/api/Lessons");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultLessonDto>>(jsonData);
                var limitedValues = values.Take(8).ToList();
                return View(limitedValues);
            }
            return View();
        }
    }
}
