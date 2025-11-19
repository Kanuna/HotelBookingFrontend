using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.ViewModels
{
    public class ContactInfoViewModel : ViewModelBase
    {
        private string _email;
        public string Email
        {
            get => _email;
            //set => this.RaiseAndSetIfChanged(ref _email, value);
            set
            {
                if (_email != value)
                {
                    _email = value;
                    OnPropertyChanged(nameof(Email));
                }
            }
        }

        private string _phone;
        public string Phone
        {
            get => _phone;
            //set => this.RaiseAndSetIfChanged(ref _phone, value);
            set
            {
                if (_phone != value)
                {
                    _phone = value;
                    OnPropertyChanged(nameof(Phone));
                }
            }
        }
    }
}
