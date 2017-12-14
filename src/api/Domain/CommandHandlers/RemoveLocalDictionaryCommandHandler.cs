using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Inshapardaz.Desktop.Domain.Command;
using Inshapardaz.Desktop.Domain.Contexts;
using Microsoft.EntityFrameworkCore;
using Paramore.Brighter;

namespace Inshapardaz.Desktop.Domain.CommandHandlers
{
    public class RemoveLocalDictionaryCommandHandler : RequestHandlerAsync<RemoveLocalDictionaryCommand>
    {
        private readonly IApplicationDatabase _applicationDatabase;

        public RemoveLocalDictionaryCommandHandler(IApplicationDatabase applicationDatabase)
        {
            _applicationDatabase = applicationDatabase;
        }

        public override async Task<RemoveLocalDictionaryCommand> HandleAsync(RemoveLocalDictionaryCommand command, CancellationToken cancellationToken = new CancellationToken())
        {
            var dictionary = await _applicationDatabase.Dictionaries.SingleOrDefaultAsync(x => x.Id == command.DictionaryId, cancellationToken);
            if (dictionary != null)
            {
                File.Delete(dictionary.FilePath);
                _applicationDatabase.Dictionaries.Remove(dictionary);
                await _applicationDatabase.SaveChangesAsync(cancellationToken);
            }

            return command;
        }
    }
}
