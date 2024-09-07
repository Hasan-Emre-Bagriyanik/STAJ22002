using Teacher_Schedule_Api.Dtos.LessonDtos;

namespace Teacher_Schedule_Api.Repositories.LessonRepositories
{
    public interface ILessonRepository
    {
        Task<List<ResultLessonDto>> GetAllLessonAsync();
        Task CreateLesson(CreateLessonDto createLessonDto);
        Task UpdateLesson(UpdateLessonDto updateLessonDto);
        Task DeleteLesson(int id);
        Task<GetByIDLessonDto> GetByIDLesson(int id);
        Task<List<GetByIDLessonDto>> GetByIDLessonBranch(int id);

    }
}
