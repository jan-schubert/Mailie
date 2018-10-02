using Grace.DependencyInjection;
using Mailie.DataAccessLayer;
using Mailie.DependencyInjection;
using Mailie.Events;
using Mailie.Views.MailAccountSettings;
using Mailie.Views.Shell;
using Microsoft.EntityFrameworkCore;

namespace Mailie
{
  public class Bootstrapper
  {
    private DependencyInjectionContainer _container;

    public MainView Run()
    {
      ConfigureDependencies();
      MigrateDatabase();
      return RunApp();
    }

    private void MigrateDatabase()
    {
//      _container.Locate<MailieDbContext>().Database.EnsureDeleted();
      _container.Locate<MailieDbContext>().Database.Migrate();
    }

    private MainView RunApp()
    {
      return _container.Locate<MainView>();
    }

    private void ConfigureDependencies()
    {
      _container = new DependencyInjectionContainer();

      _container.Configure(c => c.Export<MailAccountOverviewViewModel>().As<MailAccountOverviewViewModel>().Lifestyle.Singleton());
      _container.Configure(c => c.Export<MailAccountViewModel>().As<MailAccountViewModel>().Lifestyle.Singleton());
      _container.Configure(c => c.Export<UnitOfWork>().As<IUnitOfWork>().Lifestyle.Singleton());
      _container.Configure(c => c.Export<EventAggregator>().As<IEventAggregator>().Lifestyle.Singleton());
      _container.Configure(c => c.ExportFactory<IServiceLocator>(() => new ServiceLocator(_container)).Lifestyle.Singleton());
      _container.Configure(c => c.ExportFactory(() =>
      {
        var optionsBuilder = new DbContextOptionsBuilder<MailieDbContext>();
        optionsBuilder.UseSqlite("Data Source=Mailie.db");
        return new MailieDbContext(optionsBuilder.Options);
      }).Lifestyle.Singleton());

      StaticServiceLocator.SetCurrent(_container.Locate<IServiceLocator>());
    }
  }
}