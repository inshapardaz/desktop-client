using Microsoft.AspNetCore.Hosting;

namespace Inshapardaz.Desktop.Api
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseStartup<Startup>()
                .UseUrls("http://*:9586")
                .Build();

            host.Run();
        }
    }
}
