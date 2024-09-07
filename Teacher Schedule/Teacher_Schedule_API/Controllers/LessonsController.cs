using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Teacher_Schedule_Api.Dtos.LessonDtos;
using Teacher_Schedule_Api.Dtos.TeacherDtos;
using Teacher_Schedule_Api.Repositories.LessonRepositories;

namespace Teacher_Schedule_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonsController : ControllerBase
    {
        public readonly ILessonRepository _lessonRepository;

        public LessonsController(ILessonRepository lessonRepository)
        {
            _lessonRepository = lessonRepository;
        }

        [HttpGet]
        public async Task<IActionResult> LessonList()
        {
            var values = await _lessonRepository.GetAllLessonAsync();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateLesson(CreateLessonDto createLessonDto)
        {
            await _lessonRepository.CreateLesson(createLessonDto);
            return Ok("Ders Başarılı Bir Şekilde Eklendi...");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLesson(int id)
        {
            await _lessonRepository.DeleteLesson(id);
            return Ok("Ders Başarılı Bir Şekilde Silindi...");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIDLesson(int id)
        {
            var values = await _lessonRepository.GetByIDLesson(id);
            return Ok(values);
        }

        [HttpGet("GetByIDLessonBranch/{id}")]
        public async Task<IActionResult> GetByIDLessonBranch(int id)
        {
            var values = await _lessonRepository.GetByIDLessonBranch(id);
            return Ok(values);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateLesson(UpdateLessonDto updateLessonDto)
        {
            await _lessonRepository.UpdateLesson(updateLessonDto);
            return Ok("Ders Başarılı Bir Şekilde Güncellendi...");
        }
    }
}
