using System.Threading.Tasks;
using Inshapardaz.Desktop.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Inshapardaz.Desktop.Api.Controllers
{
    public class WordDetailController : Controller
    {
        [HttpGet]
        [Route("/api/words/{id}/details", Name = "GetWordDetailsById")]
        public async Task<WordDetailView> GetForWord(int id)
        {
            return await ApiClient.Get<WordDetailView>($"/api/words/{id}/details");
        }

        [HttpGet]
        [Route("/api/details/{id}", Name = "GetDetailsById")]
        public async Task<WordDetailView> Get(int id)
        {
            return await ApiClient.Get<WordDetailView>($"/api/details/{id}");
        }
    }
}