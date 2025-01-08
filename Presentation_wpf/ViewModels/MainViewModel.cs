using CommunityToolkit.Mvvm.ComponentModel;
using System.Diagnostics.Metrics;
using Microsoft.Extensions.DependencyInjection;
namespace Presentation_wpf.ViewModels;

public partial class MainViewModel :ObservableObject
{
    private readonly IServiceProvider _serviceProvider;
    [ObservableProperty]
    private ObservableObject _currentViewModel = null!;

    public MainViewModel(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        CurrentViewModel = _serviceProvider.GetRequiredService<ContactsViewModel>();
    }
}
