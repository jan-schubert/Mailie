using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Mailie.DataAccessLayer
{
  public class MailieDesignTimeContextFactory : IDesignTimeDbContextFactory<MailieDbContext>
  {
    public MailieDbContext CreateDbContext(string[] args)
    {
      var optionsBuilder = new DbContextOptionsBuilder<MailieDbContext>();
      optionsBuilder.UseSqlite("Data Source=Mailie.db");

      return new MailieDbContext(optionsBuilder.Options);
    }
  }
}