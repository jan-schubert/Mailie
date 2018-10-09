using System.Threading.Tasks;

namespace Mailie.DataAccessLayer
{
  public interface IUnitOfWork
  {
    IRepository<MailAccount> MailAccountRepository { get; }
    IRepository<MailContact> MailContactRepository { get; }
    IRepository<MailAddress> MailAddressRepository { get; }
    IRepository<MailMessage> MailMessageRepository { get; }

    IRepository<TEntity> GetRepository<TEntity>()
      where TEntity : Entity;

    bool HasChanges();

    Task SaveChangesAsync();

    void ResetEntityState(Entity entity);
  }
}