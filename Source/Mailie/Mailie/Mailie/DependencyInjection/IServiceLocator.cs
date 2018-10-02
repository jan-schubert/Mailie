using System;

namespace Mailie.DependencyInjection
{
  public interface IServiceLocator
  {
    T Get<T>();
    object Get(Type type);
  }
}