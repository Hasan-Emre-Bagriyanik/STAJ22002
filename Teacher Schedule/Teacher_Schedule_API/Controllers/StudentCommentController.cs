using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Teacher_Schedule_Api.Repositories.StudentCommentRepositories;

namespace Teacher_Schedule_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentCommentController : ControllerBase
    {
        public readonly IStudentCommentRepository _studentCommentRepository;

        public StudentCommentController(IStudentCommentRepository studentCommentRepository)
        {
            this._studentCommentRepository = studentCommentRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudentCommentAsync() 
        {
            var values = await _studentCommentRepository.GetAllStudentCommentAsync();
            return Ok(values);
        }
    }
}
