using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Inshapardaz.Desktop.Api.Client
{
    public static class ApiClient
    {
        private static readonly Uri BaseUrl = new Uri("http://ipapi.azurewebsites.net/");

        public static async Task<T> Get<T>(string url)
        {
            var client = new HttpClient();
            var stringTask = await client.GetStringAsync(new Uri(BaseUrl, url));
            stringTask = stringTask.Replace(BaseUrl.ToString(), "http://localhost:9586/");
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(stringTask);
        }
    }
}