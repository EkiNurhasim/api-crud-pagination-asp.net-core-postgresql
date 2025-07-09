using System;
using Microsoft.EntityFrameworkCore;
using Practice.Services;

namespace Practice.Data;

public static class Configuration
{
    public static IServiceCollection ConfigureSetUp(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IPersonService, PersonService>();
        services.AddDbContext<ApplicationContext>(options => options.UseNpgsql(configuration.GetConnectionString("DBStore")));
        services.AddCors(options =>
        {
            options.AddDefaultPolicy(policy =>
            {
                policy.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();
            });
        });
        
        return services;
    }
}
