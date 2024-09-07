using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Teacher_Schedule_Api.Dtos.TeacherDtos;
using Teacher_Schedule_Api.Repositories.TeacherRepositories;

namespace Teacher_Schedule_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        public readonly ITeacherRepository _teacherRepository;

        public TeachersController(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        [HttpGet]
        public async Task<IActionResult> TeacherList()
        {
            var values = await _teacherRepository.GetAllTeachersAsync();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTeacher(CreateTeachersDto createTeachersDto)
        {
            await _teacherRepository.CreateTeacher(createTeachersDto);
            return Ok("Öğretmen Başarılı Bir Şekilde Eklendi...");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeacher(int id)
        {
            await _teacherRepository.DeleteTeacher(id);
            return Ok("Öğretmen Başarılı Bir Şekilde Silindi...");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIDTeacher(int id)
        {
            var values = await _teacherRepository.GetByIDTeacher(id);
            return Ok(values);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTeacher(UpdateTeachersDto updateTeachersDto)
        {
            await _teacherRepository.UpdateTeacher(updateTeachersDto);
            return Ok("Öğretmen Başarılı Bir Şekilde Güncellendi...");
        }
    }
}
