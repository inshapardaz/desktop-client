using Inshapardaz.Desktop.Common.Models;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Common.Queries
{
    public class GetDetailByIdQuery : IQuery<WordDetailModel>
    {
        public int Id { get; set; }

        public int DictionaryId { get; set; }
    }
}