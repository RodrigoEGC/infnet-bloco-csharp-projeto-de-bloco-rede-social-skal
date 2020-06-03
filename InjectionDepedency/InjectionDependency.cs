using Data;
using Data.Repositories;
using Domain.Model.Interfaces.Repositories;
using Domain.Model.Interfaces.Services;
using Domain.Service;
using Domain.Service.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InjectionDepedency
{
    public static class InjectionDependency
    {
        public static void RegisterInjections(
            this IServiceCollection services, 
            IConfiguration configuration) 
        { 
            services.AddDbContext<UserContext>(options => 
                options.UseSqlServer(configuration.GetConnectionString("UserContext"))); 
            
            services.AddScoped<IProfileService, ProfileService>(); 
            services.AddScoped<IProfileRepository, ProfileRepository>();
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<IPostRepository, PostRepository>();
            //services.AddScoped<IBlobService, BlobService>();
            //services.AddScoped<IBlobRepository, BlobRepository>();
        }
        public static void RegisterDataAccess(
            this IServiceCollection services, 
            IConfiguration configuration) 
        { 
            services.AddDbContext<UserContext>(options => 
                options.UseSqlServer(configuration.GetConnectionString("UserContext"))); 
            services.AddScoped<IProfileRepository, ProfileRepository>();
        }
    }
}
