using System;
using System.Collections.Generic;
using System.Text;

namespace OTPService.Service
{
    public interface IOTPGenerator
    {
        string GenerateSecret();

        int GenerateOtp(string secret, DateTime currentTime);
    }
}
