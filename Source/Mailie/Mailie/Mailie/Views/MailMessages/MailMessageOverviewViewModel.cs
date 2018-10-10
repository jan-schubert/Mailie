using System.Linq;
using System.Threading.Tasks;
using Mailie.DataAccessLayer;
using Mailie.Events;
using Mailie.Mvvm;
using Microsoft.EntityFrameworkCore;

namespace Mailie.Views.MailMessages
{
  public class MailMessageOverviewViewModel : OverviewViewModel<MailMessage, MailMessageView>
  {
    public MailMessageOverviewViewModel(IUnitOfWork unitOfWork, IEventAggregator eventAggregator)
      : base(unitOfWork, eventAggregator)
    {
    }

    protected override async Task OnLoadedAsync(object parameter)
    {
      var mailContactId = ((MailContact)parameter).Id;
      foreach (var item in await UnitOfWork.GetRepository<MailMessage>().GetAllQuery().Where(x => x.MailContact.Id == mailContactId).ToListAsync())
        Items.Add(item);
    }
  }
}