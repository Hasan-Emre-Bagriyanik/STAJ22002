using Dapper;
using Teacher_Schedule_Api.Models.DapperContext;

namespace Teacher_Schedule_Api.Repositories.StatisticRepositories
{
    public class StatisticRepository : IStatisticRepository
    {
        public readonly Context _context;

        public StatisticRepository(Context context)
        {
            _context = context;
        }

        public int LessonCount()
        {
            string query = "Select Count(*) From Lessons";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public int NumberOfProgrammeLessonsOnFriday()
        {
            string query = "select count(*) from Schedules where DayOfWeek='Cuma'";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public int NumberOfProgrammeLessonsOnMonday()
        {
            string query = "select count(*) from Schedules where DayOfWeek='Pazartesi'";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public int NumberOfProgrammeLessonsOnThursday()
        {
            string query = "select count(*) from Schedules where DayOfWeek='Perşembe'";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public int NumberOfProgrammeLessonsOnTuesday()
        {
            string query = "select count(*) from Schedules where DayOfWeek='Salı'";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public int NumberOfProgrammeLessonsOnWednesday()
        {
            string query = "select count(*) from Schedules where DayOfWeek='Çarşamba'";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public int StudentCommentCount()
        {
            string query = "Select Count(*) From StudentComment";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public int TeacherCount()
        {
            string query = "Select Count(*) From Teachers";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }
    }
}
