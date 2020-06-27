using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OTP.Filters;
using OTP.Services;
using OTP.Services.Contracts;
using OTPService.Installer;

namespace OTP.Installers
{
    public class APIInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddCors();
            services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);
            services.AddMvc(options =>
                    {
                        options.Filters.Add<ValidationFilter>();
                    })
                    .AddFluentValidation(opt => opt.RegisterValidatorsFromAssemblyContaining<Startup>());

            services.AddOTPGenerator(new OTPService.Settings.OTPSettings(){ NumberOfDigits = 6, OTPLifeTime = 30 });

            services.AddTransient<IUserSecretService, UserSecretService>();
        }
    }
}
