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
        public static void UpdateDatabase(){
            using (var context = new ApplicationDatabase())
            {
                context.Database.Migrate();
            }
        }       

        public static void RegisterDatabases(IServiceCollection services, IProvideUserSettings settings)
        {
            var applicationDbFile = Path.Combine(settings.DataFolder, "application.dat");
            var applicationConnectionString = new SqliteConnectionStringBuilder { DataSource = applicationDbFile };

            services.AddEntityFrameworkSqlite()
                    .AddDbContext<ApplicationDatabase>(
                        options => options.UseSqlite(applicationConnectionString.ConnectionString));
            
            services.AddTransient<IApplicationDatabase, ApplicationDatabase>();
        }
    }
}