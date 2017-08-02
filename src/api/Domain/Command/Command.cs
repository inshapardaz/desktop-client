using System;
using Paramore.Brighter;

namespace Inshapardaz.Desktop.Domain.Command
{
    public abstract class Command : IRequest
    {
        protected Command()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
    }
}