using Microsoft.EntityFrameworkCore;
using NadinSoftProject.Host;
using Persistence;

namespace NadinSoftProject.Host
{
    public static class DataSeeder
    {
        public static WebApplication Seed(this WebApplication host)
        {
            try
            {
                using (var scope = host.Services.CreateScope())
                {
                    var serviceProvider = scope.ServiceProvider;

                    var databaseContext = serviceProvider.GetRequiredService<ApplicationDbContext>();

                    databaseContext.Database.Migrate();
                    databaseContext.SaveChanges();
                }

                return host;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return host;
            }
        }
    }
}
