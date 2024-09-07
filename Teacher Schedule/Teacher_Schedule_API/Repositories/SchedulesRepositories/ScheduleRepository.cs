using Dapper;
using Teacher_Schedule_Api.Dtos.ScheduleDtos;
using Teacher_Schedule_Api.Models.DapperContext;

namespace Teacher_Schedule_Api.Repositories.SchedulesRepositories
{
    public class ScheduleRepository : IScheduleRepository
    {
        public readonly Context _context;

        public ScheduleRepository(Context context)
        {
            _context = context;
        }

        public async Task CreateSchedule(CreateScheduleDto createScheduleDto)
        {
            string query = "Insert into Schedules (TeacherID, LessonID, DayOfWeek, StartTime, EndTime) values (@teacherID, @lessonID, @dayOfWeek, @startTime, @EndTime)";
            var parameters = new DynamicParameters();
            parameters.Add("@teacherID", createScheduleDto.TeacherID);
            parameters.Add("@lessonID", createScheduleDto.LessonID);
            parameters.Add("@dayOfWeek", createScheduleDto.DayOfWeek);
            parameters.Add("@startTime", createScheduleDto.StartTime);
            parameters.Add("@endTime", createScheduleDto.EndTime);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }

        }

        public async Task DeleteByTeacherId(int id)
        {
            string query = "Delete From Schedules Where TeacherID = @teacherID";
            var parameters = new DynamicParameters();
            parameters.Add("@teacherID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteSchedule(int id)
        {

            string query = "Delete From Schedules Where ScheduleID = @scheduleID";
            var parameters = new DynamicParameters();
            parameters.Add("@scheduleID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultScheduleDto>> GetAllScheduleAsync()
        {
            string query = "Select * from Schedules";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultScheduleDto>(query);
                return values.ToList();
            }
        }

        public async Task<List<GetByIDScheduleDto>> GetByIDSchedule(int id)
        {
            string query = "Select  s.ScheduleID, s.TeacherID, s.LessonID, t.FirstName + ' ' + t.LastName as TeacherName, l.LessonName,s.DayOfWeek, s.StartTime, s.EndTime From Schedules s inner join Teachers t on s.TeacherID = t.TeacherID inner join Lessons l on s.LessonID = l.LessonID  Where s.TeacherID = @teacherID";
            var parameters = new DynamicParameters();
            parameters.Add("@teacherID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<GetByIDScheduleDto>(query, parameters);
                return values.ToList();
            }
        }

        public async Task<List<GetByIDScheduleDto>> GetByIDScheduleByTeacher(int id)
        {
            string query = "Select  s.ScheduleID, s.TeacherID, s.LessonID, t.FirstName + ' ' + t.LastName as TeacherName, l.LessonName,s.DayOfWeek, s.StartTime, s.EndTime From Schedules s inner join Teachers t on s.TeacherID = t.TeacherID inner join Lessons l on s.LessonID = l.LessonID  Where s.TeacherID = @teacherID";
            var parameters = new DynamicParameters();
            parameters.Add("@teacherID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<GetByIDScheduleDto>(query, parameters);
                return values.ToList();
            }
        }

        public async Task UpdateSchedule(UpdateScheduleDto updateScheduleDto)
        {
            string query = "Update Schedules set TeacherID = @teacherID, LessonID = @lessonID, DayOfWeek = @dayOfWeek, StartTime = @startTime, EndTime = @endTime  Where ScheduleID = @scheduleID";
            var parameters = new DynamicParameters();
            parameters.Add("@teacherID", updateScheduleDto.TeacherID);
            parameters.Add("@lessonID", updateScheduleDto.LessonID);
            parameters.Add("@dayOfWeek", updateScheduleDto.DayOfWeek);
            parameters.Add("@startTime", updateScheduleDto.StartTime);
            parameters.Add("@endTime", updateScheduleDto.EndTime);
            parameters.Add("@scheduleID", updateScheduleDto.ScheduleID);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);

            }
        }
    }
}
