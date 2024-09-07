using Dapper;
using Teacher_Schedule_Api.Dtos.WhoWeAreDtos;
using Teacher_Schedule_Api.Models.DapperContext;

namespace Teacher_Schedule_Api.Repositories.WhoWeAreRepositories
{
    public class WhoWeAreRepository : IWhoWeAreRepository
    {
        public readonly Context _context;

        public WhoWeAreRepository(Context context)
        {
            _context = context;
        }

        public async Task CreateWhoWeAre(CreateWhoWeAreDto createWhoWeAreDto)
        {
            string query = "Insert into WhoWeAre (Title, Subtitle, Contents) values (@title, @subtitle, @contents)";
            var parameters = new DynamicParameters();
            parameters.Add("@title", createWhoWeAreDto.Title);
            parameters.Add("@subtitle", createWhoWeAreDto.Subtitle);
            parameters.Add("@contents", createWhoWeAreDto.Contents);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }

        }

        public async Task DeleteWhoWeAre(int id)
        {

            string query = "Delete From WhoWeAre Where WhoWeAreID = @whoWeAreID";
            var parameters = new DynamicParameters();
            parameters.Add("@whoWeAreID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultWhoWeAreDto>> GetAllWhoWeAreAsync()
        {
            string query = "Select * From WhoWeAre";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultWhoWeAreDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIDWhoWeAreDto> GetByIDWhoWeAre(int id)
        {
            string query = "Select * From WhoWeAre Where WhoWeAreID = @whoWeAreID";
            var parameters = new DynamicParameters();
            parameters.Add("@whoWeAreID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIDWhoWeAreDto>(query, parameters);
                return values;
            }
        }

        public async Task UpdateWhoWeAre(UpdateWhoWeAreDto updateWhoWeAreDto)
        {
            string query = "Update WhoWeAre set Title = @title, Subtitle = @subtitle, Contents = @contents Where WhoWeAreID = @whoWeAreID";
            var parameters = new DynamicParameters();
            parameters.Add("@title", updateWhoWeAreDto.Title);
            parameters.Add("@subtitle", updateWhoWeAreDto.Subtitle);
            parameters.Add("@contents", updateWhoWeAreDto.Contents);
            parameters.Add("@whoWeAreID", updateWhoWeAreDto.WhoWeAreID);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);

            }
        }
    }
}
