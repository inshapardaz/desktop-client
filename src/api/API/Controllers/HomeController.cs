using System.Threading.Tasks;
using Inshapardaz.Desktop.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Inshapardaz.Desktop.Api.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet, Route("api")]
        public async Task<EntryView> Index()
        {
            return await ApiClient.Get<EntryView>("api");
        }
    }
}