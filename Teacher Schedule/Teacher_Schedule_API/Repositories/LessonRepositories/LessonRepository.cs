using Dapper;
using Teacher_Schedule_Api.Dtos.LessonDtos;
using Teacher_Schedule_Api.Dtos.TeacherDtos;
using Teacher_Schedule_Api.Models.DapperContext;

namespace Teacher_Schedule_Api.Repositories.LessonRepositories
{
    public class LessonRepository : ILessonRepository
    {
        public readonly Context _context;

        public LessonRepository(Context context)
        {
            _context = context;
        }

        public async Task CreateLesson(CreateLessonDto createLessonDto)
        {
            string query = "Insert into Lessons (LessonName, Branch, Image) values (@lessonName, @branch, @image)";
            var parameters = new DynamicParameters();
            parameters.Add("@lessonName", createLessonDto.LessonName);
            parameters.Add("@branch", createLessonDto.Branch);
            parameters.Add("@image", createLessonDto.Image);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }

        }

        public async Task DeleteLesson(int id)
        {

            string query = "Delete From Lessons Where LessonID = @lessonID";
            var parameters = new DynamicParameters();
            parameters.Add("@lessonID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultLessonDto>> GetAllLessonAsync()
        {
            string query = "Select * From Lessons";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultLessonDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIDLessonDto> GetByIDLesson(int id)
        {
            string query = "Select * From Lessons Where LessonID = @lessonID";
            var parameters = new DynamicParameters();
            parameters.Add("@lessonID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIDLessonDto>(query, parameters);
                return values;
            }
        }

        public async Task<List<GetByIDLessonDto>> GetByIDLessonBranch(int id)
        {
            string query = "select l.LessonID, t.FirstName + ' ' + t.LastName as TeacherName, l.LessonName, l.Branch  from Lessons l inner join Teachers T on l.TeacherID = t.TeacherID where l.Branch = t.Branch and t.TeacherID = @teacherID";
            var parameters = new DynamicParameters();
            parameters.Add("@teacherID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<GetByIDLessonDto>(query, parameters);
                return values.ToList();
            }

        }

        public async Task UpdateLesson(UpdateLessonDto updateLessonDto)
        {
            string query = "Update Lessons set LessonName = @lessonName, Branch = @branch, Image = @image Where LessonID = @lessonID";
            var parameters = new DynamicParameters();
            parameters.Add("@lessonName", updateLessonDto.LessonName);
            parameters.Add("@branch", updateLessonDto.Branch);
            parameters.Add("@image", updateLessonDto.Image);
            parameters.Add("@lessonID", updateLessonDto.LessonID);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);

            }
        }
    }
}
