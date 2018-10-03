using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Mailie.DataAccessLayer;
using Mailie.Events;
using Microsoft.EntityFrameworkCore;

namespace Mailie.Mvvm
{
  public class OverviewViewModel<TEntity, TDetailView> : UnitOfWorkViewModelBase
    where TEntity : Entity
  {
    public OverviewViewModel(IUnitOfWork unitOfWork, IEventAggregator eventAggregator)
      : base(unitOfWork, eventAggregator)
    {
      NewCommand = new DelegateCommand<object, object>(OnNew);
    }

    public ObservableCollection<TEntity> Items { get; } = new ObservableCollection<TEntity>();
    public DelegateCommand<object, object> NewCommand { get; }

    public TEntity SelectedItem
    {
      set
      {
        if (value != null)
          EventAggregator.PublishAsync(new NavigationEvent(typeof(TDetailView), value));
      }
    }

    protected override async Task OnLoadedAsync(object parameter)
    {
      foreach (var item in await UnitOfWork.GetRepository<TEntity>().GetAllQuery().ToListAsync())
        Items.Add(item);
    }

    protected override Task OnUnloadedAsync()
    {
      Items.Clear();
      return Task.CompletedTask;
    }

    protected Task OnNew(object arg)
    {
      return EventAggregator.PublishAsync(new NavigationEvent(typeof(TDetailView)));
    }
  }
}