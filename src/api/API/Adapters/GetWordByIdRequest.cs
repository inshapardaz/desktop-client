using System;
using System.Threading;
using System.Threading.Tasks;
using Inshapardaz.Desktop.Api.Model;
using Inshapardaz.Desktop.Api.Renderers;
using Inshapardaz.Desktop.Common.Exceptions;
using Inshapardaz.Desktop.Common.Models;
using Inshapardaz.Desktop.Common.Queries;
using Paramore.Brighter;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Api.Adapters
{
    public class GetWordByIdRequest : IRequest
    {
        public Guid Id { get; set; }

        public int DictionaryId { get; set; }

        public int WordId { get; set; }

        public WordView Result { get; set; }
    }

    public class GetWordByIdRequestHandler : RequestHandlerAsync<GetWordByIdRequest>
    {
        private readonly IQueryProcessor _queryProcessor;
        private readonly IRenderResponseFromObject<WordModel, WordView> _wordRenderer;


        public GetWordByIdRequestHandler(IQueryProcessor queryProcessor, IRenderResponseFromObject<WordModel, WordView> wordRenderer)
        {
            _queryProcessor = queryProcessor;
            _wordRenderer = wordRenderer;
        }

        public override async Task<GetWordByIdRequest> HandleAsync(GetWordByIdRequest command, CancellationToken cancellationToken = new CancellationToken())
        {
            var model = await _queryProcessor.ExecuteAsync(new GetWordByIdQuery
            {
                DictionaryId = command.DictionaryId,
                WordId = command.WordId
            }, cancellationToken);
            if (model == null)
            {
                throw new NotFoundException();
            }
            command.Result = _wordRenderer.Render(model);
            return await base.HandleAsync(command, cancellationToken);
        }
    }
}
