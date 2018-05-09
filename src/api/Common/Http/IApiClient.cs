using System.IO;
using System.Threading.Tasks;

namespace Inshapardaz.Desktop.Common.Http
{
    public interface IApiClient
    {
        Task<T> Get<T>(string url, string accept = "application/json");
        Task<Stream> GetStream(string url);
    }
}