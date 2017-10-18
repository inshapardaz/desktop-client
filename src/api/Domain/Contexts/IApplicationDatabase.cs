using System.Threading;
using System.Threading.Tasks;
using Inshapardaz.Desktop.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Inshapardaz.Desktop.Domain.Contexts
{
    public interface IApplicationDatabase
    {
        DbSet<Setting> Setting { get; set; }

        DbSet<Dictionary> Dictionaries { get; set; }

        int SaveChanges();

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}