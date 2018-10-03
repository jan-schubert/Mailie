using System;
using System.Collections.Concurrent;
using Microsoft.EntityFrameworkCore;

namespace Mailie.DataAccessLayer
{
  public class UnitOfWork : IUnitOfWork
  {
    private readonly MailieDbContext _mailieDbContext;
    private readonly ConcurrentDictionary<Type, IRepository> _repositories = new ConcurrentDictionary<Type, IRepository>();

    public UnitOfWork(MailieDbContext mailieDbContext)
    {
      _mailieDbContext = mailieDbContext;
    }

    public IRepository<MailAccount> MailAccountRepository => GetRepository<MailAccount>();

    public IRepository<TEntity> GetRepository<TEntity>()
      where TEntity : Entity
    {
      return (IRepository<TEntity>) _repositories.GetOrAdd(typeof(TEntity), new GenericRepository<TEntity>(_mailieDbContext));
    }

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