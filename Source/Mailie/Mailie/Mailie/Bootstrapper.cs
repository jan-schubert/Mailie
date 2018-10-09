using Grace.DependencyInjection;
using Mailie.Cryptography;
using Mailie.DataAccessLayer;
using Mailie.DependencyInjection;
using Mailie.Events;
using Mailie.Services;
using Mailie.Views.MailMessages;
using Mailie.Views.Settings.MailAccounts;
using Mailie.Views.Settings.MailContacts;
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

      _container.Configure(c => c.Export<MailMessageService>().As<IMailMessageService>().Lifestyle.Singleton());
      _container.Configure(c => c.Export<MailContactService>().As<IMailContactService>().Lifestyle.Singleton());

      _container.Configure(c => c.Export<MailAccountOverviewViewModel>().As<MailAccountOverviewViewModel>().Lifestyle.Singleton());
      _container.Configure(c => c.Export<MailAccountViewModel>().As<MailAccountViewModel>().Lifestyle.Singleton());
      _container.Configure(c => c.Export<MailContactOverviewViewModel>().As<MailContactOverviewViewModel>().Lifestyle.Singleton());
      _container.Configure(c => c.Export<MailContactViewModel>().As<MailContactViewModel>().Lifestyle.Singleton());
      _container.Configure(c => c.Export<Views.MailContacts.MailContactOverviewViewModel>().As<Views.MailContacts.MailContactOverviewViewModel>().Lifestyle.Singleton());
      _container.Configure(c => c.Export<MailMessageOverviewView>().As<MailMessageOverviewView>().Lifestyle.Singleton());
      _container.Configure(c => c.Export<MailMessageView>().As<MailMessageView>().Lifestyle.Singleton());

      _container.Configure(c => c.Export<UnitOfWork>().As<IUnitOfWork>().Lifestyle.Singleton());
      _container.Configure(c => c.Export<EventAggregator>().As<IEventAggregator>().Lifestyle.Singleton());
      _container.Configure(c => c.Export<CryptographyService>().As<ICryptographyService>().Lifestyle.Singleton());
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