using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using HotelBooking.API;
using HotelBooking.ViewModels;

namespace HotelBooking.Views;

public partial class LoginView : UserControl
{
    public LoginView()
    {
        InitializeComponent();

        var apiClient = new ApiClient("http://localhost:8080/users/");
        var vm = new LoginViewModel(apiClient);

        vm.OnLoginSuccess = () =>
        {
            Content = new MainView();
        };

        DataContext = vm;
    }


    private void CreateButton_click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        //Content = new CreateUserView();
        Content = new MainView();
    }
}