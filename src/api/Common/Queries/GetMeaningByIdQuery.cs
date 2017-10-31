using Inshapardaz.Desktop.Common.Models;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Common.Queries
{
    public class GetMeaningByIdQuery : IQuery<MeaningModel>
    {
        public int MeaningId { get; set; }

        public int DictionaryId { get; set; }
    }
}