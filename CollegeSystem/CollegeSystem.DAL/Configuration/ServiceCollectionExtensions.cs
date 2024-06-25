using CollegeSystem.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CollegeSystem.DAL.Configuration;

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMigrate(this IServiceCollection services)
        {
            // Create a service scope factory once
            var serviceProvider = services.BuildServiceProvider();
            using var scope = serviceProvider.CreateScope();
        
            // Resolve the database context
            var context = scope.ServiceProvider.GetRequiredService<CollegeSystemDbContext>();
        
            // Apply migrations
            context.Database.Migrate();
        
            // Return the service collection
            return services;
        }
    }
    