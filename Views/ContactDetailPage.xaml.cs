using ContactApp.ViewModels;

namespace ContactApp.Views;

public partial class ContactDetailPage : ContentPage
{
	public ContactDetailPage()
	{
		InitializeComponent();
		BindingContext = new ContactDetailViewModel();
	}
}