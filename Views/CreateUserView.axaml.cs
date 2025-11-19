using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using HotelBooking.API;
using HotelBooking.ViewModels;

namespace HotelBooking.Views;

public partial class CreateUserView : UserControl
{
    public CreateUserView()
    {
        InitializeComponent();

        var apiClient = new ApiClient("http://localhost:8080/users/");
        var vm = new CreateUserViewModel(apiClient);

        vm.OnUserCreated = () =>
        {
            Content = new LoginView();
        };

        DataContext = vm;
    }

    private void LoginButton_click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        Content = new LoginView();
    }
}