using EasyJamAPI.Services;
using EasyJamBLL.DTO;
using EasyJamBLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace EasyJamAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly JwtService _jwtService;
        private readonly LoginService _service;

        public AuthController(JwtService jwtService, LoginService service)
        {
            _jwtService = jwtService;
            _service = service;
        }


        [HttpPost]
        public IActionResult Login(AdminLoginDTO dto)
        {
            try
            {
                AdminDTO user = _service.Login(dto);
                string token = _jwtService.Createtoken(user.Id.ToString(), user.Email, "user");
                return Ok(new { token });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
