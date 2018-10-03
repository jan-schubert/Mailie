namespace Mailie.DataAccessLayer
{
  public interface IUnitOfWork
  {
    IRepository<MailAccount> MailAccountRepository { get; }

    IRepository<TEntity> GetRepository<TEntity>()
      where TEntity : Entity;

    bool HasChanges();

    void SaveChanges();

    void ResetEntityState(Entity entity);
  }
}