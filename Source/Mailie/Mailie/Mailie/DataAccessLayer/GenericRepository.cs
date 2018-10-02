using System;
using System.Linq;

namespace Mailie.DataAccessLayer
{
  public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : Entity
  {
    private readonly MailieDbContext _mailieDbContext;

    public GenericRepository(MailieDbContext mailieDbContext)
    {
      _mailieDbContext = mailieDbContext;
    }

    public TEntity GetById(int id)
    {
      return _mailieDbContext.Set<TEntity>().Find(id);
    }

    public TEntity CreateNew()
    {
      var entity = Activator.CreateInstance<TEntity>();
      entity.CreationDateTime = DateTime.Now;
      entity.LastModifiedDateTime = DateTime.Now;
      return entity;
    }

    public IQueryable<TEntity> GetAllQuery()
    {
      return _mailieDbContext.Set<TEntity>();
    }

    public void Add(TEntity entity)
    {
      _mailieDbContext.Set<TEntity>().Add(entity);
    }
  }
}