using System.Threading.Tasks;
using Inshapardaz.Desktop.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Inshapardaz.Desktop.Api.Controllers
{
    public class ThesaurusController : Controller
    {
        [HttpGet("api/alternates/{word}", Name = "GetWordAlternatives")]
        public async Task<PageView<WordView>> Get(string word, int pageNumber = 1, int pageSize = 10)
        {
            return await ApiClient.Get<PageView<WordView>>($"api/alternates/{word}?pageNumber={pageNumber}&pageSize={pageSize}");
        }
    }
}