using System;
using System.Linq;

namespace Mailie.DataAccessLayer
{
  public class GenericRepository<TEntity>
    : IRepository<TEntity>, IRepository
    where TEntity : Entity
  {
    private readonly MailieDbContext _mailieDbContext;

    public GenericRepository(MailieDbContext mailieDbContext)
    {
      _mailieDbContext = mailieDbContext;
    }

    Entity IRepository.CreateNew()
    {
      return CreateNew();
    }

    IQueryable<Entity> IRepository.GetAllQuery()
    {
      return GetAllQuery();
    }

    void IRepository.Add(Entity entity)
    {
      Add((TEntity) entity);
    }

    void IRepository.Delete(Entity entity)
    {
      Delete((TEntity) entity);
    }

    Entity IRepository.GetById(int id)
    {
      return GetById(id);
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

    public void Delete(TEntity entity)
    {
      _mailieDbContext.Set<TEntity>().Remove(entity);
    }
  }
}