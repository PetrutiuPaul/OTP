using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OTP.Filters;

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

        }
    }
}
