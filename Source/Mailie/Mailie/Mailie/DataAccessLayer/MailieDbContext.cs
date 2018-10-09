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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<MailAccount>()
        .HasKey(p => new { p.Id });

      modelBuilder.Entity<MailContact>()
        .HasKey(p => new { p.Id });

      modelBuilder.Entity<MailMessage>()
        .HasKey(p => new { p.Id });

      modelBuilder.Entity<MailAddress>()
        .HasKey(p => new { p.Id });

      modelBuilder.Entity<MailAddress>()
        .HasOne(x => x.MailContact)
        .WithMany(x => x.MailAddresses)
        .HasForeignKey(x => x.MailContactId);
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