using ContactApp.Repositories;
using ContactApp.ViewModels;

namespace ContactApp.Views;

public partial class ContactsPage : ContentPage
{
	public ContactsPage()
	{
		InitializeComponent();

		BindingContext = new ContactsPageViewModel(App.ContactRepository);
	}
}