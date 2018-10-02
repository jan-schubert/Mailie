namespace Mailie.DataAccessLayer
{
  public interface IUnitOfWork
  {
    IRepository<MailAccount> MailAccountRepository { get; }
    bool HasChanges();
    void SaveChanges();
    void ResetEntityState(Entity entity);
  }
}