using System.Linq;

namespace Mailie.DataAccessLayer
{
  public interface IRepository<TEntity>
    where TEntity : Entity
  {
    TEntity GetById(int id);
    TEntity CreateNew();
    IQueryable<TEntity> GetAllQuery();
    void Add(TEntity entity);
    void Delete(TEntity entity);
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