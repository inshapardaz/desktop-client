using System.Collections.Generic;
using System.Threading.Tasks;
using Inshapardaz.Desktop.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Inshapardaz.Desktop.Api.Controllers
{
    public class MeaningController : Controller
    {
        [HttpGet]
        [Route("api/words/{id}/meanings", Name = "GetWordMeaningById")]
        public async Task<MeaningView> GetMeaningForWord(int id)
        {
            return await ApiClient.Get<MeaningView>($"api/words/{id}/meanings");
        }

        [HttpGet("api/meanings/{id}", Name = "GetMeaningById")]
        public async Task<MeaningView> Get(int id)
        {
            return await ApiClient.Get<MeaningView>($"api/meanings/{id}");
        }

        [HttpGet]
        [Route("api/words/{id}/meanings/contexts/{context}", Name = "GetWordMeaningByContext")]
        public async Task<IEnumerable<MeaningView>> GetMeaningForContext(int id, string context)
        {
            return await ApiClient.Get<IEnumerable<MeaningView>>($"api/words/{id}/meanings/contexts/{context}");
        }
    }
}