using System.Collections.Generic;
using Inshapardaz.Desktop.Common.Models;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Common.Queries
{
    public class GetMeaningsByWordIdQuery : IQuery<IEnumerable<MeaningView>>
    {
        public int Id { get; set; }
    }
}