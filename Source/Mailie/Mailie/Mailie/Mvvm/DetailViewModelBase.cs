using System.Threading.Tasks;
using Mailie.DataAccessLayer;
using Mailie.Events;

namespace Mailie.Mvvm
{
  public class DetailViewModelBase<TEntity, TOverviewView> : UnitOfWorkViewModelBase where TEntity : Entity
  {
    private TEntity _item;

    public DetailViewModelBase(IUnitOfWork unitOfWork, IEventAggregator eventAggregator)
      : base(unitOfWork, eventAggregator)
    {
      SaveCommand = new DelegateCommand<object, object>(OnSave);
      DeleteCommand = new DelegateCommand<object, object>(OnDelete);
    }

    public DelegateCommand<object, object> SaveCommand { get; }
    public DelegateCommand<object, object> DeleteCommand { get; }

    public TEntity Item
    {
      get => _item;
      set
      {
        if (Equals(value, _item)) return;
        _item = value;
        InvokePropertyChanged();
      }
    }

    private Task OnSave(object arg)
    {
      UnitOfWork.SaveChanges();
      return EventAggregator.PublishAsync(new NavigationEvent(typeof(TOverviewView)));
    }

    private Task OnDelete(object arg)
    {
      UnitOfWork.GetRepository<TEntity>().Delete(_item);
      UnitOfWork.SaveChanges();
      return EventAggregator.PublishAsync(new NavigationEvent(typeof(TOverviewView)));
    }

    protected override Task OnLoadedAsync(object parameter)
    {
      if (parameter == null)
      {
        Item = UnitOfWork.GetRepository<TEntity>().CreateNew();
        UnitOfWork.GetRepository<TEntity>().Add(Item);
      }
      else
      {
        Item = OnSetItemFromParameter(parameter);
      }

      return Task.CompletedTask;
    }

    public virtual TEntity OnSetItemFromParameter(object parameter)
    {
      return (TEntity) parameter;
    }

    protected override Task OnUnloadedAsync()
    {
      Item = null;
      return Task.CompletedTask;
    }

    protected override Task OnDoNotSaveChangesAsync()
    {
      UnitOfWork.ResetEntityState(Item);
      return Task.CompletedTask;
    }
  }
}