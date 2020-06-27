using System;

namespace OTPService.Helpers
{
    internal class ConvertHelper
    {
        static internal byte[] GetBigEndianBytes(long input)
        {
            var data = BitConverter.GetBytes(input);
            Array.Reverse(data);
            return data;
        }
    }
}
