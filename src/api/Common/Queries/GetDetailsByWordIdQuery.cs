using System.Collections.Generic;
using Inshapardaz.Desktop.Common.Models;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Common.Queries
{
    public class GetDetailsByWordIdQuery : IQuery<IEnumerable<WordDetailModel>>
    {
        public int Id { get; set; }

        public int DictionaryId { get; set; }
    }
}