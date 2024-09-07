using Dapper;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Net.WebSockets;
using Teacher_Schedule_Api.Dtos.TeacherDtos;
using Teacher_Schedule_Api.Models.DapperContext;

namespace Teacher_Schedule_Api.Repositories.TeacherRepositories
{
    public class TeacherRepository : ITeacherRepository
    {
        public readonly Context _context;

        public TeacherRepository(Context context)
        {
            _context = context;
        }

        public async Task CreateTeacher(CreateTeachersDto createTeachersDto)
        {
            string query = "Insert into Teachers (FirstName, LastName, Branch, WeeklyHours, Image) values (@firstName, @lastName, @branch, @weeklyHours, @image)";
            var parameters = new DynamicParameters();
            parameters.Add("@firstName", createTeachersDto.FirstName);
            parameters.Add("@lastName", createTeachersDto.LastName);
            parameters.Add("@branch", createTeachersDto.Branch);
            parameters.Add("@weeklyHours", createTeachersDto.WeeklyHours);
            parameters.Add("@image", createTeachersDto.Image);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteTeacher(int id)
        {
            string query = "Delete From Teachers Where TeacherID = @teacherID";
            var parameters = new DynamicParameters();
            parameters.Add("@teacherID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultTeachersDto>> GetAllTeachersAsync()
        {
            string query = "Select * From Teachers";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultTeachersDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIDTeacherDto> GetByIDTeacher(int id)
        {
            string query = "Select * From Teachers Where TeacherID = @teacherID";
            var parameters = new DynamicParameters();
            parameters.Add("@teacherID", id);
            using (var connection = _context.CreateConnection())
            {
               var values =  await connection.QueryFirstOrDefaultAsync<GetByIDTeacherDto>(query, parameters);
                return values;
            }
        }

    

        public async Task UpdateTeacher(UpdateTeachersDto updateTeachersDto)
        {
            string query = "Update Teachers set FirstName = @firstName, LastName = @lastName, Branch = @branch, WeeklyHours = @weeklyHours, Image = @image Where TeacherID = @teacherID";
            var parameters = new DynamicParameters();
            parameters.Add("@firstName", updateTeachersDto.FirstName);
            parameters.Add("@lastName", updateTeachersDto.LastName);
            parameters.Add("@branch", updateTeachersDto.Branch);
            parameters.Add("@weeklyHours", updateTeachersDto.WeeklyHours);
            parameters.Add("@image", updateTeachersDto.Image);
            parameters.Add("@teacherID", updateTeachersDto.TeacherID);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);

            }
        }
    }
}
