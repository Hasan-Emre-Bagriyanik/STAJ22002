using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Teacher_Schedule_Api.Dtos.LoginDtos;
using Teacher_Schedule_Api.Models.DapperContext;
using Teacher_Schedule_Api.Tools;

namespace Teacher_Schedule_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly Context _context;

        public LoginController(Context context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> SingIn(CreateLoginDto createLoginDto)
        {
            string query = "Select * From AppUser Where UserName = @userName and Password = @password";
            string query2 = "Select UserID, UserRole, RoleName From AppUser a inner join AppRole u on a.UserRole = u.RoleID  Where UserName = @userName and Password = @password";
            var parameters = new DynamicParameters();
            parameters.Add("@userName", createLoginDto.UserName);
            parameters.Add("@password", createLoginDto.Password);
            using (var connection = _context.CreateConnection())
            {
                var user = await connection.QueryFirstOrDefaultAsync(query, parameters);
                var userRole = await connection.QueryFirstOrDefaultAsync(query2, parameters);
                if (user != null && userRole != null)
                {
                    GetCheckAppUserViewModel model = new GetCheckAppUserViewModel
                    {
                        UserName = user.UserName,
                        Id = userRole.UserID,
                        RoleId= userRole.UserRole,
                        Role = userRole.RoleName
                    };
                    var token = JwtTokenGenerator.GenerateToken(model);
                    return Ok(token);
                }
                else
                {
                    return Ok("Başarısız");
                }
            }
        }
    }
}
