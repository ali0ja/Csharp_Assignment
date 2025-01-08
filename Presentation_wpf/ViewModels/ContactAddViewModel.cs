

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;

namespace Presentation_wpf.ViewModels;

public partial class ContactAddViewModel:ObservableObject
{
    private readonly IServiceProvider _serviceProvider;
    
    
    [ObservableProperty]
    private string _title ="Add New contact";

    [RelayCommand]
    private void GoToContact()
    {
        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<ContactsViewModel>();
    }
    public ContactAddViewModel(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;

    }
}
