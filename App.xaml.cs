using ContactApp.Repositories;

namespace ContactApp;

public partial class App : Application
{
	public static ContactRepository ContactRepository { get; private set; }
	public App(ContactRepository repo)
	{
		InitializeComponent();

		MainPage = new AppShell();
		ContactRepository = repo;
	}
}
