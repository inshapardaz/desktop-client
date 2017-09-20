using System.Collections.Generic;
using Inshapardaz.Desktop.Common.Models;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Common.Queries
{
    public class GetMeaningsByWordDetailIdQuery : IQuery<IEnumerable<MeaningModel>>
    {
        public int DetailId { get; set; }
    }
}