using Dapper;
using Teacher_Schedule_Api.Dtos.LessonDtos;
using Teacher_Schedule_Api.Dtos.StudentCommentDtos;
using Teacher_Schedule_Api.Models.DapperContext;

namespace Teacher_Schedule_Api.Repositories.StudentCommentRepositories
{
    public class StudentCommentRepository : IStudentCommentRepository
    {
        public readonly Context _context;

        public StudentCommentRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultStudentCommentDto>> GetAllStudentCommentAsync()
        {

            string query = "Select * From StudentComment";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultStudentCommentDto>(query);
                return values.ToList();
            }
        }
    }
}
