using System.Threading;
using System.Threading.Tasks;
using Inshapardaz.Desktop.Common;
using Inshapardaz.Desktop.Common.Models;
using Inshapardaz.Desktop.Domain.Command;
using Inshapardaz.Desktop.Domain.Contexts;
using Inshapardaz.Desktop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Paramore.Brighter;

namespace Inshapardaz.Desktop.Domain.CommandHandlers
{
    public class AddLocalDictionaryCommandHandler : RequestHandlerAsync<AddLocalDictionaryCommand>
    {
        private readonly IApplicationDatabase _applicationDatabase;

        public AddLocalDictionaryCommandHandler(IApplicationDatabase applicationDatabase)
        {
            _applicationDatabase = applicationDatabase;
        }

        public override async Task<AddLocalDictionaryCommand> HandleAsync(AddLocalDictionaryCommand command, CancellationToken cancellationToken = new CancellationToken())
        {
            var dictionary = await _applicationDatabase.Dictionaries.SingleOrDefaultAsync(x => x.Id == command.Dictionary.Id, cancellationToken);
            if (dictionary != null)
            {
                command.Dictionary.Map(dictionary);
            }
            else
            {
                var entity = command.Dictionary.Map<DictionaryModel, Dictionary>();
                entity.FilePath = command.FilePath;
                _applicationDatabase.Dictionaries.Add(entity);
            }

            await _applicationDatabase.SaveChangesAsync(cancellationToken);
            return command;
        }
    }
}
