using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ContactApp.Repositories;
using ContactApp.Views;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace ContactApp.ViewModels
{
    partial class ContactsPageViewModel : ObservableObject
    {
        ContactRepository contactRepository;
        public ObservableCollection<Models.Contact> Contacts { get; } = new();

        public ContactsPageViewModel(ContactRepository contactRepository)
        {
            this.contactRepository = contactRepository;
        }

        [ObservableProperty]
        public Models.Contact selectedContact;

        [RelayCommand]
        async Task GoToDetails(Contact contact)
        {
            if (contact == null) return;

            await Shell.Current.GoToAsync(nameof(ContactDetailPage), new Dictionary<string, object>
            {
                { "Contact", contact }
            });
        }

        [RelayCommand]
        async Task GetContacts()
        {
            try
            {
                var contacts = await contactRepository.GetAllContact();

                if (Contacts.Count != 0) Contacts.Clear();

                foreach (var c in contacts)
                    Contacts.Add(c);
            }
            catch (Exception ex) 
            {
                Debug.WriteLine($"Unable to get contacts: {ex.Message}");
                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
            }
        }
    }
}
