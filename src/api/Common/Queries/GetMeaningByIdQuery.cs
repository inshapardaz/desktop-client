using Inshapardaz.Desktop.Common.Models;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Common.Queries
{
    public class GetMeaningByIdQuery : IQuery<MeaningView>
    {
        public int Id { get; set; }
    }
}