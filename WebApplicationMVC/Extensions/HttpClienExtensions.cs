using Domain.Model.Interfaces.Services;
using Domain.Model.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationMVC.HttpServices;

namespace WebApplicationMVC.Extensions
{
    public static class HttpClienExtensions
    {
        public static void RegisterHttpClients(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var userHttpOptionsSection = configuration.GetSection(nameof(UserHttpOptions));
            var userHttpOptions = userHttpOptionsSection.Get<UserHttpOptions>();

            services.AddHttpClient(userHttpOptions.Name, x => { x.BaseAddress = userHttpOptions.ApiBaseUrl; });

            services.AddScoped<IProfileService, ProfileHttpService>();
            //services.AddScoped<IAuthHttpService, AuthHttpService>();
        }
    }
}
