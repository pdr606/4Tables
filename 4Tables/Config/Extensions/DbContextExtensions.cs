using _4Tables.Config.Extensions;
using Microsoft.EntityFrameworkCore;

namespace _4Tables.Config.Extensions
{
    public static class DbContextExtensions
    {
        public static void Migrate(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var contexts = (from asm in AppDomain.CurrentDomain.GetAssemblies()
                                from type in asm.GetTypes()
                                where type.IsClass && type.BaseType == typeof(DbContext)
                                select type).ToArray();

                foreach (var item in contexts)
                {
                    (scope.ServiceProvider.GetRequiredService(item) as DbContext)
                        .Database.Migrate();
                }
            }
        }
    }
}
