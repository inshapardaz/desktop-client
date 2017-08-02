using Inshapardaz.Desktop.Common.Models;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Common.Queries
{
    public class GetWordByIdQuery : IQuery<WordView>
    {
        public int Id { get; set; }
    }
}