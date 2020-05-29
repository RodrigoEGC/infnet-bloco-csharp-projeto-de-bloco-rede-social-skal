using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Crosscutting.Identity
{
    public static class IdentityHosting
    {
        private static void AddDbContext(IServiceCollection services, IConfiguration configuration) 
        { 
            services.AddDbContext<AuthContext>(options => 
            options.UseSqlServer(configuration.GetConnectionString("AuthContext"))); 
        }

        public static void RegisterIdentityForMvc(
            this IServiceCollection services, 
            IConfiguration configuration) 
        { 
            AddDbContext(services, configuration); 
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<AuthContext>(); 
        }

        public static void RegisterIdentityForWebApi(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            AddDbContext(services, configuration);
            services.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<AuthContext>();
        }
    }
}
