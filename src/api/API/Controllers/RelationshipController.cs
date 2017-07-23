using System.Threading.Tasks;
using Inshapardaz.Desktop.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Inshapardaz.Desktop.Api.Controllers
{
    public class RelationshipController : Controller
    {
        [HttpGet]
        [Route("/api/words/{id}/relationships", Name = "GetWordRelationsById")]
        public async Task<RelationshipView> GetRelationshipForWord(int id)
        {
            return await ApiClient.Get<RelationshipView>($"/api/words/{id}/relationships");
        }

        [HttpGet("/api/relationships/{id}")]
        public async Task<RelationshipView> Get(int id)
        {
            return await ApiClient.Get<RelationshipView>($"/api/relationships/{id}");
        }
    }
}