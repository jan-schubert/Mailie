using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mailie.Views.Shell
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class NavigationView
  {
    public ListView NavigationListView => ListView;

    public NavigationView()
    {
      InitializeComponent();
    }
  }
}