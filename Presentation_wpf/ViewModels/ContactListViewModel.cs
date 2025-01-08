

using Business.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Presentation_wpf.ViewModels;

public partial class ContactListViewModel :ObservableObject
{
    private readonly IContactService _contactService;

    public ContactListViewModel(IContactService contactService)
    {
        _contactService = contactService;
    }
}
