using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Inshapardaz.Desktop.Common.Http
{
    public class ApiClient : IApiClient
    {
        private readonly IConfigurationRoot _configuration;

        public ApiClient(IConfigurationRoot configuration)
        {
            _configuration = configuration;
        }

        private Uri BaseUrl { get => new Uri(_configuration["apiAddress"]); }
        private string LocalApiUrl { get => _configuration["localApiAddress"]; }

        public async Task<T> Get<T>(string url, string accept = "application/json")
        {
            var client = new HttpClient();
            if (!string.IsNullOrWhiteSpace(accept))
            {
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue(accept));
            }
            var stringTask = await client.GetStringAsync(new Uri(BaseUrl, url));
            stringTask = stringTask.Replace(BaseUrl.ToString(), LocalApiUrl);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(stringTask);
        }

        public async Task<Stream> GetStream(string url)
        {
            var client = new HttpClient();
            url = url.Replace(LocalApiUrl, BaseUrl.ToString());
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/x-sqlite3"));
            return await client.GetStreamAsync(new Uri(BaseUrl, url));
        }
    }
}