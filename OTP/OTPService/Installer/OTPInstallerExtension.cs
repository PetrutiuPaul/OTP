using Microsoft.Extensions.DependencyInjection;
using OTPService.Service;
using OTPService.Settings;
using System;

namespace OTPService.Installer
{
    public static class OTPInstallerExtension
    {
        public static void AddOTPGenerator(this IServiceCollection services, OTPSettings settings)
        {
            var generator = new OTPGenerator(settings);
            services.AddTransient<IOTPGenerator>(provider => { return generator; });
        }
    }
}
