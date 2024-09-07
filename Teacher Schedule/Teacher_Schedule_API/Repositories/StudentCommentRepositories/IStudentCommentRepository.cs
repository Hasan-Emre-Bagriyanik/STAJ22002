using Teacher_Schedule_Api.Dtos.StudentCommentDtos;

namespace Teacher_Schedule_Api.Repositories.StudentCommentRepositories
{
    public interface IStudentCommentRepository
    {
        Task<List<ResultStudentCommentDto>> GetAllStudentCommentAsync();
    }
}
