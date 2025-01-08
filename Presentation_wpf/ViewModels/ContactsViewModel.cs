

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;

namespace Presentation_wpf.ViewModels;
public partial class ContactsViewModel : ObservableObject
{
    private readonly IServiceProvider _serviceProvider;
    

    [ObservableProperty]

    private string _title = "Contacts";

    [RelayCommand]
    private void GoToAddcContact()
    {
        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel =_serviceProvider.GetRequiredService<ContactAddViewModel>();
    }
    public ContactsViewModel(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;

    }
}

