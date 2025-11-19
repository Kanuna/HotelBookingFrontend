using Avalonia.Controls;
using HotelBooking.API;
using HotelBooking.ViewModels;

namespace HotelBooking.Views;

public partial class MainView : UserControl
{
    private readonly ApiClient api = new ApiClient("http://localhost:8080/hotels");
    public MainView()
    {
        InitializeComponent();
        DataContext = new MainViewModel(api);
    }
}