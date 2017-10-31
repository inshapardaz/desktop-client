using System.IO;
using Inshapardaz.Desktop.Common;
using Inshapardaz.Desktop.Domain.Contexts;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Inshapardaz.Desktop.Domain
{
    public static class DomainModule
    {
        public static void UpdateDatabase(IProvideUserSettings settings)
        {
            var connectionString = CreateApplicationConnectionString(settings);
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDatabase>();
            optionsBuilder.UseSqlite(connectionString.ConnectionString);

            using (var context = new ApplicationDatabase(optionsBuilder.Options))
            {
                context.Database.Migrate();
            }
        }

        public static void RegisterDatabases(IServiceCollection services, IProvideUserSettings settings)
        {
            services.AddEntityFrameworkSqlite()
                    .AddDbContext<ApplicationDatabase>(
                        options => options.UseSqlite(CreateApplicationConnectionString(settings).ConnectionString));
            
            services.AddTransient<IApplicationDatabase, ApplicationDatabase>();
        }

        private static SqliteConnectionStringBuilder CreateApplicationConnectionString(IProvideUserSettings settings)
        {
            var applicationDbFile = Path.Combine(settings.DataFolder, "application.dat");
            var connectionString = new SqliteConnectionStringBuilder {DataSource = applicationDbFile};
            return connectionString;
        }
    }
}