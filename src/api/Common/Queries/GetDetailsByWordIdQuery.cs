using System.Collections.Generic;
using Inshapardaz.Desktop.Common.Models;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Common.Queries
{
    public class GetDetailsByWordIdQuery : IQuery<IEnumerable<WordDetailView>>
    {
        public int Id { get; set; }
    }
}