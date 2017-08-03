using Inshapardaz.Desktop.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Inshapardaz.Desktop.Domain.Contexts
{
    public interface IApplicationDatabase
    {
        DbSet<Setting> Setting { get; set; }

        int SaveChanges();

    }
}