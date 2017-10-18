using Inshapardaz.Desktop.Common;
using Microsoft.Extensions.DependencyInjection;

namespace Inshapardaz.Desktop.Database.Client
{
    public static class DatabaseClientModule
    {
        public static void RegisterDatabases(IServiceCollection services, IProvideUserSettings settings)
        {
            services.AddTransient<IProvideDatabase, DatabaseProvider>();
        }
    }
}