
using Business.Interfaces;
using Business.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Presentation_wpf.ViewModels;
using Presentation_wpf.Views;
using System.Configuration;
using System.Windows;

namespace Presentation_wpf;


public partial class App : Application
{
    private IHost _host;


    public App()
        {
        _host = Host.CreateDefaultBuilder()
            .ConfigureServices(services =>
            {

                services.AddSingleton<IFileService>(new FileService(AppDomain.CurrentDomain.BaseDirectory, "Contact.json"));
                services.AddSingleton<IContactRepository, ContactRepository>();
                services.AddTransient<IContactService, ContactService>();

                services.AddTransient<ContactsViewModel>();
                services.AddTransient<ContactAddViewModel>();
                services.AddTransient<ContactDetailsViewModel>();
                services.AddTransient<ContactListViewModel>();
                services.AddTransient<ContactEditViewModel>();

                services.AddTransient<AddContactView>();
                services.AddTransient<ContactsView>();
                services.AddTransient<DetailContactView>();
                services.AddTransient<ListContactView>();
                services.AddTransient<EditContactView>();

                services.AddSingleton<MainViewModel>();
                services.AddSingleton<MainWindow>();
            })
            .Build();
          
        
      }


    protected override void OnStartup(StartupEventArgs e)
    {
        
        var mainViewModel = _host.Services.GetRequiredService<MainWindow>();
        mainViewModel.CurrentViewModel= _host.Services.GetRequiredService<ContactsViewModel>();

        var mainWindow = _host.Services.GetRequiredService<MainWindow>();
        mainWindow.Show();
    }

}