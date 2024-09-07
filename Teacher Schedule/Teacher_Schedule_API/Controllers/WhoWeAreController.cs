using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Teacher_Schedule_Api.Dtos.WhoWeAreDtos;
using Teacher_Schedule_Api.Repositories.WhoWeAreRepositories;

namespace Teacher_Schedule_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WhoWeAreController : ControllerBase
    {
        public readonly IWhoWeAreRepository _WhoWeAreRepository;

        public WhoWeAreController(IWhoWeAreRepository WhoWeAreRepository)
        {
            _WhoWeAreRepository = WhoWeAreRepository;
        }

        [HttpGet]
        public async Task<IActionResult> WhoWeAreList()
        {
            var values = await _WhoWeAreRepository.GetAllWhoWeAreAsync();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateWhoWeAre(CreateWhoWeAreDto createWhoWeAreDto)
        {
            await _WhoWeAreRepository.CreateWhoWeAre(createWhoWeAreDto);
            return Ok("Biz Kimiz Başarılı Bir Şekilde Eklendi...");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWhoWeAre(int id)
        {
            await _WhoWeAreRepository.DeleteWhoWeAre(id);
            return Ok("Biz Kimiz Başarılı Bir Şekilde Silindi...");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIDWhoWeAre(int id)
        {
            var values = await _WhoWeAreRepository.GetByIDWhoWeAre(id);
            return Ok(values);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateWhoWeAre(UpdateWhoWeAreDto updateWhoWeAreDto)
        {
            await _WhoWeAreRepository.UpdateWhoWeAre(updateWhoWeAreDto);
            return Ok("Biz Kimiz Başarılı Bir Şekilde Güncellendi...");
        }
    }
}
