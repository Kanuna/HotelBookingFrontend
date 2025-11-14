using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace HotelBooking.Views;

public partial class CreateUserView : UserControl
{
    public CreateUserView()
    {
        InitializeComponent();
    }

    private void LoginButton_click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        Content = new LoginView();
    }
}