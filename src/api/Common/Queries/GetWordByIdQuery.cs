using Inshapardaz.Desktop.Common.Models;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Common.Queries
{
    public class GetWordByIdQuery : IQuery<WordModel>
    {
        public int Id { get; set; }
    }
}