using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace HotelBooking.Views;

public partial class LoginView : UserControl
{
    public LoginView()
    {
        InitializeComponent();
    }

    private void LoginButton_click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {

    }

    private void CreateButton_click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        Content = new CreateUserView();
    }
}