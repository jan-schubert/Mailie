using System.Threading.Tasks;

namespace Mailie.Mvvm
{
  public interface IViewUnloaded
  {
    Task UnloadedAsync();
  }
}