using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Teacher_Schedule_Api.Repositories.StatisticRepositories;

namespace Teacher_Schedule_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        public readonly IStatisticRepository _statisticsRepository;

        public StatisticsController(IStatisticRepository statisticsRepository)
        {
            _statisticsRepository = statisticsRepository;
        }

        [HttpGet("LessonCount")]
        public IActionResult LessonCount()
        {
            return Ok(_statisticsRepository.LessonCount());
        }

        [HttpGet("NumberOfProgrammeLessonsOnFriday")]
        public IActionResult NumberOfProgrammeLessonsOnFriday()
        {
            return Ok(_statisticsRepository.NumberOfProgrammeLessonsOnFriday());
        }


        [HttpGet("NumberOfProgrammeLessonsOnMonday")]
        public IActionResult NumberOfProgrammeLessonsOnMonday()
        {
            return Ok(_statisticsRepository.NumberOfProgrammeLessonsOnMonday());
        }

        [HttpGet("NumberOfProgrammeLessonsOnThursday")]
        public IActionResult NumberOfProgrammeLessonsOnThursday()
        {
            return Ok(_statisticsRepository.NumberOfProgrammeLessonsOnThursday());
        }

        [HttpGet("NumberOfProgrammeLessonsOnTuesday")]
        public IActionResult NumberOfProgrammeLessonsOnTuesday()
        {
            return Ok(_statisticsRepository.NumberOfProgrammeLessonsOnTuesday());
        }

        [HttpGet("NumberOfProgrammeLessonsOnWednesday")]
        public IActionResult NumberOfProgrammeLessonsOnWednesday()
        {
            return Ok(_statisticsRepository.NumberOfProgrammeLessonsOnWednesday());
        }

        [HttpGet("StudentCommentCount")]
        public IActionResult StudentCommentCount()
        {
            return Ok(_statisticsRepository.StudentCommentCount());
        }

        [HttpGet("TeacherCount")]
        public IActionResult TeacherCount()
        {
            return Ok(_statisticsRepository.TeacherCount());
        }

    }
}
