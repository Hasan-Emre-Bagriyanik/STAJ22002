using Teacher_Schedule_Api.Dtos.ScheduleDtos;

namespace Teacher_Schedule_Api.Repositories.SchedulesRepositories
{
    public interface IScheduleRepository
    {
        Task<List<ResultScheduleDto>> GetAllScheduleAsync();
        Task CreateSchedule(CreateScheduleDto createScheduleDto);
        Task UpdateSchedule(UpdateScheduleDto updateScheduleDto);
        Task DeleteSchedule(int id);
        Task DeleteByTeacherId(int id);
        Task<List<GetByIDScheduleDto>> GetByIDSchedule(int id);
        Task<List<GetByIDScheduleDto>> GetByIDScheduleByTeacher(int id);

    }
}
