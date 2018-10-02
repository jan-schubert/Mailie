using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Mailie.Annotations;
using Mailie.DataAccessLayer;
using Mailie.Events;

namespace Mailie.Mvvm
{
  public class UnitOfWorkViewModelBase : IViewLoaded, IViewUnloaded, INotifyPropertyChanged
  {
    protected readonly IEventAggregator EventAggregator;
    protected readonly IUnitOfWork UnitOfWork;

    public UnitOfWorkViewModelBase(IUnitOfWork unitOfWork, IEventAggregator eventAggregator)
    {
      UnitOfWork = unitOfWork;
      EventAggregator = eventAggregator;
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public Task LoadedAsync(object parameter)
    {
      return OnLoadedAsync(parameter);
    }

    public async Task UnloadedAsync()
    {
      if (UnitOfWork.HasChanges())
      {
        var messageBoxEvent = new MessageBoxEvent("Question", "Save changes?", "Yes", "No");
        await EventAggregator.PublishAsync(messageBoxEvent);
        if (messageBoxEvent.Result)
          await SaveChangesAsync();
        else
          await OnDoNotSaveChangesAsync();
      }

      await OnUnloadedAsync();
    }

    private Task SaveChangesAsync()
    {
      UnitOfWork.SaveChanges();
      return OnSaveChanges();
    }

    protected virtual Task OnDoNotSaveChangesAsync()
    {
      return Task.CompletedTask;
    }

    protected virtual Task OnSaveChanges()
    {
      return Task.CompletedTask;
    }

    protected virtual Task OnLoadedAsync(object parameter)
    {
      return Task.CompletedTask;
    }

    protected virtual Task OnUnloadedAsync()
    {
      return Task.CompletedTask;
    }

    [NotifyPropertyChangedInvocator]
    protected virtual void InvokePropertyChanged([CallerMemberName] string propertyName = null)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
  }
}