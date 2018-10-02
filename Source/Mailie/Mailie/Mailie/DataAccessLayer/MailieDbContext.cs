using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Mailie.DataAccessLayer
{
  public class MailieDbContext : DbContext
  {
    public MailieDbContext(DbContextOptions options)
      : base(options)
    {
    }

    public DbSet<MailAccount> MailAccounts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<MailAccount>()
        .HasKey(p => new {p.Id});
    }

    public override int SaveChanges()
    {
      ChangeTracker.Entries<Entity>().Where(x => x.State == EntityState.Modified).ToList().ForEach(x =>
      {
        x.Entity.LastModifiedDateTime = DateTime.Now;
      });

      return base.SaveChanges();
    }
  }
}