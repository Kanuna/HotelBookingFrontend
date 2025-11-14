using Avalonia.Controls;
using HotelBooking.ViewModels;

namespace HotelBooking.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        Content = new LoginView();
    }
}
