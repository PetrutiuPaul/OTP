using System;

namespace OTP.Contracts.Requests
{
    public class GetUserOTPRequest
    {
        public string Username { get; set; }

        public DateTime UserTime { get; set; }
    }
}
