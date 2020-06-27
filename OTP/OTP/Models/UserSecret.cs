using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OTP.Models
{
    public class UserSecret
    {
        public Guid Id { get; set; }

        public string Username { get; set; }

        public string Secret { get; set; }
    }
}

