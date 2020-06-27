using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OTP.Contracts.Requests;
using OTP.Contracts.Response;
using OTP.Data.Context;
using OTP.Exceptions;
using OTP.Models;
using OTP.Services.Contracts;
using OTPService.Service;

namespace OTP.Services
{
    public class UserSecretService : IUserSecretService
    {
        private readonly IOTPGenerator _OTPGenerator;
        private readonly AppDbContext _appDbContext;

        public UserSecretService(IOTPGenerator oTPGenerator, AppDbContext appDbContext)
        {
            _OTPGenerator = oTPGenerator;
            _appDbContext = appDbContext;
        }

        public async Task<UserOTPResponse> GetUserOTP(GetUserOTPRequest getUserOTPRequest)
        {
            var secret = await GetUserSecret(getUserOTPRequest.Username);

            var OTP = _OTPGenerator.GenerateOtp(secret, getUserOTPRequest.UserTime);

            return new UserOTPResponse()
            {
                OTP = OTP
            };
        }

        public async Task<RegisterUserResponse> RegisterUser(RegisterUserRequest registerUserRequest)
        {
            if (await UserExist(registerUserRequest.Username))
                throw new UserSecretException("User already registered!");

            try
            {
                var modelToAdd = new Models.UserSecret()
                {
                    Secret = _OTPGenerator.GenerateSecret(),
                    Username = registerUserRequest.Username,
                };

                await _appDbContext.UserSecrets.AddAsync(modelToAdd);
                await _appDbContext.SaveChangesAsync();

                return new RegisterUserResponse() { UserName = registerUserRequest.Username };
            }
            catch (Exception e)
            {
                throw new UserSecretException("Error on register", e.InnerException);
            }
        }

        private async Task<string> GetUserSecret(string username)
        {
            var secret = await _appDbContext.UserSecrets.FirstOrDefaultAsync(x => x.Username == username);

            if (secret == null)
                throw new UserSecretException("This user is not registered yet!");

            return secret.Secret; 
        }

        private async Task<bool> UserExist(string username)
        {
            return await _appDbContext.UserSecrets.FirstOrDefaultAsync(x => x.Username == username) != null;
        }
    }
}
