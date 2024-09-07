using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Teacher_Schedule_Api.Dtos.ScheduleDtos;
using Teacher_Schedule_Api.Repositories.SchedulesRepositories;

namespace Teacher_Schedule_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchedulesController : ControllerBase
    {
        public readonly IScheduleRepository _scheduleRepository;

        public SchedulesController(IScheduleRepository ScheduleRepository)
        {
            _scheduleRepository = ScheduleRepository;
        }

        [HttpGet]
        public async Task<IActionResult> ScheduleList()
        {
            var values = await _scheduleRepository.GetAllScheduleAsync();
            return Ok(values);
        }

        [HttpPost("CreateSchedule")]
        public async Task<IActionResult> CreateSchedule(CreateScheduleDto createScheduleDto)
        {
            await _scheduleRepository.CreateSchedule(createScheduleDto);
            return Ok("Program Başarılı Bir Şekilde Eklendi...");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteSchedule(int id)
        {
            await _scheduleRepository.DeleteSchedule(id);
            return Ok("Program Başarılı Bir Şekilde Silindi...");
        }

        [HttpDelete("DeleteByTeacherId/{id}")]
        public async Task<IActionResult> DeleteByTeacherId(int id)
        {
            await _scheduleRepository.DeleteByTeacherId(id);
            return Ok("Program Başarılı Bir Şekilde Silindi...");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIDSchedule(int id)
        {
            var values = await _scheduleRepository.GetByIDSchedule(id);
            return Ok(values);
        }

        [HttpGet("GetByIDScheduleByTeacher/{id}")]
        public async Task<IActionResult> GetByIDScheduleByTeacher(int id)
        {
            var values = await _scheduleRepository.GetByIDScheduleByTeacher(id);
            return Ok(values);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSchedule(UpdateScheduleDto updateScheduleDto)
        {
            await _scheduleRepository.UpdateSchedule(updateScheduleDto);
            return Ok("Program Başarılı Bir Şekilde Güncellendi...");
        }
    }
}
