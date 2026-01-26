using Microsoft.EntityFrameworkCore;

namespace Discount.GRPC.Data
{
    public static class Extenrions
    {
        public static IApplicationBuilder UseMigration(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            using var dbContext = scope.ServiceProvider.GetRequiredService<DiscountContext>();
            dbContext.Database.MigrateAsync();//add migration,create db, update data

            return app;
        }
    }
}
