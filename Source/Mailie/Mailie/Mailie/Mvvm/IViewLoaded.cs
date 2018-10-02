using System.Threading.Tasks;

namespace Mailie.Mvvm
{
  public interface IViewLoaded
  {
    Task LoadedAsync(object parameter = null);
  }
}