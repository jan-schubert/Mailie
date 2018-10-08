using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mailie.Views.Settings.MailContacts
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MailContactView : ContentPage
	{
		public MailContactView ()
		{
			InitializeComponent ();
		}

	  private void VisualElement_OnFocused(object sender, FocusEventArgs e)
	  {
	    var viewCell = ((ViewCell)((Entry)sender).Parent);
	    ((ListView) viewCell.Parent).SelectedItem = viewCell.BindingContext;
	  }
	}
}