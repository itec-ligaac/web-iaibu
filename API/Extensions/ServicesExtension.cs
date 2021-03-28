using API.Data;
using API.Interfaces;
using API.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace API.Extensions
{
    public static class ServicesExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddCors(options => options.AddDefaultPolicy(policy => policy.AllowAnyHeader().
            AllowAnyMethod().
            AllowCredentials().
            WithOrigins("https://localhost:4200")));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
            });
            services.AddDbContext<DataContext>(options => options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));
            return services;
        }

        public static string maresteTot(this string name)
        {
            return name.ToUpper();
        }
    }
}