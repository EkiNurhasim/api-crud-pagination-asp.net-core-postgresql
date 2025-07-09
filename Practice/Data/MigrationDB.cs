using System;
using Microsoft.EntityFrameworkCore;

namespace Practice.Data;

public static class MigrationDB
{
    public async static void MigrateDB(this WebApplication app){
        try
        {
            using var scope = app.Services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
            await dbContext.Database.MigrateAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error occured when migrating database {e.Message}");
        }
    }
}
