using ContactApp.Views;

namespace ContactApp;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(ContactDetailPage), typeof(ContactDetailPage));
	}
}
