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
            var connectionString = CreateSqliteConnectionString(settings, "application.dat");
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
                        options => options.UseSqlite(CreateSqliteConnectionString(settings, "application.dat").ConnectionString));
            
            services.AddTransient<IApplicationDatabase, ApplicationDatabase>();
        }

        public static SqliteConnectionStringBuilder CreateSqliteConnectionString(IProvideUserSettings settings, string dbName)
        {
            var applicationDbFile = Path.Combine(settings.DataFolder, dbName);
            var connectionString = new SqliteConnectionStringBuilder {DataSource = applicationDbFile};
            return connectionString;
        }
    }
}