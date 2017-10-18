using System.IO;
using System.Threading.Tasks;

namespace Inshapardaz.Desktop.Common.Http
{
    public interface IApiClient
    {
        Task<T> Get<T>(string url);
        Task<Stream> GetSqlite(string url);
    }
}