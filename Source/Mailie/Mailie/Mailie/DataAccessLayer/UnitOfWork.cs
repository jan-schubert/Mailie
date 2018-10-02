using Microsoft.EntityFrameworkCore;

namespace Mailie.DataAccessLayer
{
  public class UnitOfWork : IUnitOfWork
  {
    private readonly MailieDbContext _mailieDbContext;
    private IRepository<MailAccount> _mailAccountRepository;

    public UnitOfWork(MailieDbContext mailieDbContext)
    {
      _mailieDbContext = mailieDbContext;
    }

    public IRepository<MailAccount> MailAccountRepository => _mailAccountRepository ?? (_mailAccountRepository = new GenericRepository<MailAccount>(_mailieDbContext));

    public bool HasChanges()
    {
      return _mailieDbContext.ChangeTracker.HasChanges();
    }

    public void SaveChanges()
    {
      _mailieDbContext.SaveChanges();
    }

    public void ResetEntityState(Entity entity)
    {
      var entityEntry = _mailieDbContext.Entry(entity);
      switch (entityEntry.State)
      {
        case EntityState.Added:
          entityEntry.State = EntityState.Detached;
          break;
        case EntityState.Modified:
          entityEntry.State = EntityState.Unchanged;
          break;
      }
    }
  }
}