using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Inshapardaz.Desktop.Api.Model;
using Inshapardaz.Desktop.Common;
using Inshapardaz.Desktop.Domain.Command;
using Inshapardaz.Desktop.Domain.Entities;
using Inshapardaz.Desktop.Domain.Queries;
using Paramore.Brighter;
using Paramore.Darker;
using Microsoft.Extensions.Configuration;

namespace Inshapardaz.Desktop.Api.Controllers
{
    [Route("/api/settings")]
    public class SettingsController : Controller
    {
        private readonly IQueryProcessor _queryProcessor;
        private readonly IAmACommandProcessor _commandProcessor;

        private readonly IConfigurationRoot _configuration;

        public SettingsController(IQueryProcessor queryProcessor, IAmACommandProcessor commandProcessor, IConfigurationRoot configuration)
        {
            _queryProcessor = queryProcessor;
            _commandProcessor = commandProcessor;
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<SettingsModel> Get()
        {
            var result = await _queryProcessor.ExecuteAsync(new GetSettingsQuery()) ?? new Setting();
            var retval = result.Map<Setting,SettingsModel>();
            retval.WebHomeUrl = _configuration["webHomeUrl"];
            return retval;
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody]SettingsModel model)
        {
            var updateSettingsCommand = new UpdateSettingsCommand { Setting = model.Map<SettingsModel, Setting>() };
            await _commandProcessor.SendAsync(updateSettingsCommand);

            if (updateSettingsCommand.HasAdded)
            {
                return Created(string.Empty, model);
            }

            return Ok(model);
        }
    }
}