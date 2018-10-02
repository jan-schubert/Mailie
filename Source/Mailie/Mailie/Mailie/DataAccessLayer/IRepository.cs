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
  }
}