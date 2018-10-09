using System;
using System.Linq;
using System.Linq.Expressions;

namespace Mailie.DataAccessLayer
{
  public interface IRepository<TEntity>
    where TEntity : Entity
  {
    TEntity GetBy(int id);
    TEntity GetBy(Guid guid);
    TEntity TryGetBy(Guid guid);
    TEntity CreateNew();
    IQueryable<TEntity> GetAllQuery();
    void Add(TEntity entity);
    void Delete(TEntity entity);
    void LoadCollection(TEntity entity, Expression<Func<TEntity, object>> func);
    void Update(TEntity entity);
  }

  public interface IRepository
  {
    Entity GetById(int id);
    Entity CreateNew();
    IQueryable<Entity> GetAllQuery();
    void Add(Entity entity);
    void Delete(Entity entity);
  }
}