using Inshapardaz.Desktop.Domain.Entities;
using Inshapardaz.Desktop.Domain.Entities.Dictionary;
using Microsoft.EntityFrameworkCore;

namespace Inshapardaz.Desktop.Domain
{
    public interface IDatabase
    {
        DbSet<Setting> Setting { get; set; }
        DbSet<Dictionary> Dictionary { get; set; }
        DbSet<Meaning> Meaning { get; set; }
        DbSet<Translation> Translation { get; set; }
        DbSet<Word> Word { get; set; }
        DbSet<WordDetail> WordDetail { get; set; }
        DbSet<WordRelation> WordRelation { get; set; }

        int SaveChanges();

    }
}