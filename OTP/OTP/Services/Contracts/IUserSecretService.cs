using OTP.Contracts.Requests;
using OTP.Contracts.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OTP.Services.Contracts
{
    public interface IUserSecretService
    {
        Task<RegisterUserResponse> RegisterUser(RegisterUserRequest registerUserRequest);

        Task<UserOTPResponse> GetUserOTP(GetUserOTPRequest getUserOTPRequest);
    }
}
