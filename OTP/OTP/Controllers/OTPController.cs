using Microsoft.AspNetCore.Mvc;
using OTP.Contracts.Requests;
using System.Threading.Tasks;

namespace OTP.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OTPController : ControllerBase
    {
        [HttpPost]
        [Route("RegisterUser")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserRequest registerUserRequest)
        {
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetUserOTPRequest getUserOTPRequest)
        {
            return Ok();
        }
    }
}
