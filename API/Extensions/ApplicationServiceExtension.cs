using API.Data;
using API.Interfaces;
using API.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API.Extensions {
    public static class ApplicationServiceExtension {
        public static IServiceCollection AddApplicationServices (this IServiceCollection services, IConfiguration config) {

            // Entity Framework Context
            services.AddDbContext<DataContext> (options => {
                options.UseSqlite (config.GetConnectionString ("DefaultConnection"));
            });

            // Services
            services.AddScoped<ITokenService, TokenService> ();

            // Swagger
            services.AddSwaggerGen (c => {
                c.SwaggerDoc ("v1", new OpenApiInfo { Title = "API", Version = "v1" });
            });

            return services;
        }
    }
}