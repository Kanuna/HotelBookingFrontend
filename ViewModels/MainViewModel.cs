using HotelBooking.API;
using HotelBooking.Models;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Threading.Tasks;

namespace HotelBooking.ViewModels;

public class MainViewModel : ViewModelBase
{
    public ObservableCollection<HotelDTO> Hotels { get; } =
        new ObservableCollection<HotelDTO>();


    private readonly ApiClient _api;


    public ReactiveCommand<Unit, Unit> GetHotelsCommand { get; }

    public MainViewModel(ApiClient api)
    {
        Hotels.Add(new HotelDTO
        {
            Name = "Hotel",
            Franchise = "Hotel",
            StarRating = 4,
            RoomList = new List<RoomDTO>
            {
                new RoomDTO { RoomNumber = "1", Price = 100 },
                new RoomDTO { RoomNumber = "2", Price = 110 },
                new RoomDTO { RoomNumber = "3", Price = 120 }
            }
        });

        _api = api;
        GetHotelsCommand = ReactiveCommand.CreateFromTask(GetHotels);
    }


    private async Task GetHotels()
    {
        await _api.GetHotels();
    }
}