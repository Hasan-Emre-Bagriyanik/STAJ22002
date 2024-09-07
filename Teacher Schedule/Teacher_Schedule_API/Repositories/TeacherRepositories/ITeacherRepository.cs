using Teacher_Schedule_Api.Dtos.TeacherDtos;

namespace Teacher_Schedule_Api.Repositories.TeacherRepositories
{
    public interface ITeacherRepository
    {
        Task<List<ResultTeachersDto>> GetAllTeachersAsync();
        Task CreateTeacher(CreateTeachersDto createTeachersDto);
        Task DeleteTeacher(int id);
        Task UpdateTeacher(UpdateTeachersDto updateTeachersDto);
        Task<GetByIDTeacherDto> GetByIDTeacher(int id);
    }
}
