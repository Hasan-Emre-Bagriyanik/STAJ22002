using Teacher_Schedule_Api.Dtos.WhoWeAreDtos;

namespace Teacher_Schedule_Api.Repositories.WhoWeAreRepositories
{
    public interface IWhoWeAreRepository
    {
        Task<List<ResultWhoWeAreDto>> GetAllWhoWeAreAsync();
        Task CreateWhoWeAre(CreateWhoWeAreDto createWhoWeAreDto);
        Task UpdateWhoWeAre(UpdateWhoWeAreDto updateWhoWeAreDto);
        Task DeleteWhoWeAre(int id);
        Task<GetByIDWhoWeAreDto> GetByIDWhoWeAre(int id);

    }
}
