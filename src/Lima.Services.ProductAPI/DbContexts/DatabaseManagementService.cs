using Microsoft.EntityFrameworkCore;

namespace Lima.Services.ProductAPI.DbContexts
{
    public static class DatabaseManagementService
    {
        public static void MigrationInitialization(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                serviceScope.ServiceProvider.GetService<ApplicationDbContext>().Database.Migrate();
            }
        }
    }
}
