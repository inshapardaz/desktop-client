using System.Threading.Tasks;
using Inshapardaz.Desktop.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Inshapardaz.Desktop.Api.Controllers
{
    public class DictionariesController : Controller
    {
        [HttpGet("/api/dictionaries", Name = "GetDictionaries")]
        public async Task<DictionariesView> Get()
        {
            return await ApiClient.Get<DictionariesView>("/api/dictionaries");
        }

        [HttpGet("/api/dictionaries/{id}", Name = "GetDictionaryById")]
        public async Task<DictionaryView> Get(int id)
        {
            return await ApiClient.Get<DictionaryView>($"/api/dictionaries/{id}");
        }
    }
}