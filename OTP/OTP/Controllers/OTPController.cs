using Microsoft.AspNetCore.Mvc;
using OTP.Contracts.Requests;
using OTP.Contracts.Response;
using OTP.Services.Contracts;
using System;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace OTP.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OTPController : ControllerBase
    {
        private readonly IUserSecretService _userSecretService;

        public OTPController(IUserSecretService userSecretService)
        {
            _userSecretService = userSecretService;
        }

        [HttpPost]
        [Route("RegisterUser")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserRequest registerUserRequest)
        {
            try { 
                var response = await _userSecretService.RegisterUser(registerUserRequest);

                return Ok(new Response<RegisterUserResponse>(response));
            }
            catch (Exception e)
            {
                var error = new ErrorModel()
                {
                    Message = e.Message
                };

                return BadRequest(new Response<ErrorModel>(error));
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetUserOTPRequest getUserOTPRequest)
        {
            try
            {
                var response = await _userSecretService.GetUserOTP(getUserOTPRequest);

                return Ok(new Response<UserOTPResponse>(response));
            }
            catch (Exception e)
            {
                var error = new ErrorModel()
                {
                    Message = e.Message
                };

                return BadRequest(new Response<ErrorModel>(error));
            }
        }
    }
}
