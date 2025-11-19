using HotelBooking.API;
using HotelBooking.Models;
using ReactiveUI;
using Splat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HotelBooking.ViewModels
{
    public class CreateUserViewModel : ViewModelBase
    {
        private string _password;
        private int _age;
        private string _fullName;


        public string Password
        {
            get => _password;
            set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged(nameof(Password));
                    OnPropertyChanged(nameof(CanCreate));
                }
            }
        }

        public int Age
        {
            get => _age;
            set
            {
                if (_age != value)
                {
                    _age = value;
                    OnPropertyChanged(nameof(Age));
                    OnPropertyChanged(nameof(CanCreate));
                }
            }
        }

        public string Fullname
        {
            get => _fullName;
            set
            {
                if (_fullName != value)
                {
                    _fullName = value;
                    OnPropertyChanged(nameof(Fullname));
                    OnPropertyChanged(nameof(CanCreate));
                }
            }
        }

        public string Email
        {
            get => ContactInfo.Email;
            set
            {
                if (ContactInfo.Email != value)
                {
                    ContactInfo.Email = value;
                    OnPropertyChanged(nameof(Email));
                    OnPropertyChanged(nameof(CanCreate));
                }
            }
        }

        public string Phone
        {
            get => ContactInfo.Phone;
            set
            {
                if (ContactInfo.Phone != value)
                {
                    ContactInfo.Phone = value;
                    OnPropertyChanged(nameof(Phone));
                    OnPropertyChanged(nameof(CanCreate));
                }
            }
        }

        public bool IsEmailValid
        {
            get
            {
                if (string.IsNullOrWhiteSpace(ContactInfo.Email))
                    return false;

                var emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
                return Regex.IsMatch(ContactInfo.Email, emailPattern, RegexOptions.IgnoreCase);
            }
        }

        public bool IsPhoneValid
        {
            get
            {
                if (string.IsNullOrWhiteSpace(ContactInfo.Phone))
                    return false;

                var phonePAttern = @"^\d{7,15}$";
                return Regex.IsMatch(ContactInfo.Phone, phonePAttern);
            }
        }


        public bool IsPasswordValid => !string.IsNullOrEmpty(Password) && Password.Length > 8;
        public bool isAgeValid => Age >= 18;
        public bool IsFullnameValid => !string.IsNullOrEmpty(Fullname);


        public bool CanCreate =>
            IsPasswordValid &&
            isAgeValid &&
            IsFullnameValid &&
            IsEmailValid &&
            IsPhoneValid;


        public ContactInfoViewModel ContactInfo { get; } = new();

        private readonly ApiClient _api;
        public Action? OnUserCreated {  get; set; }


        private UserDTO? _createdUser;
        public UserDTO? CreatedUser
        {
            get => _createdUser;
            set => this.RaiseAndSetIfChanged(ref _createdUser, value);
        }


        public ReactiveCommand<Unit, Unit> CreateUserCommand { get; }

        public CreateUserViewModel(ApiClient api)
        {
            _api = api;

            ContactInfo.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == nameof(ContactInfo.Email) || e.PropertyName == nameof(ContactInfo.Phone))
                {
                    OnPropertyChanged(nameof(CanCreate));
                }
            };

            CreateUserCommand = ReactiveCommand.CreateFromTask(CreateUser);
        }

        private async Task CreateUser()
        {
            var userDTO = new UserCreateDTO
            {
                FullName = Fullname,
                Age = Age,
                Password = Password,

                ContactInfo = new ContactInfoDTO
                {
                    Email = ContactInfo.Email,
                    Phone = ContactInfo.Phone,
                }
            };

            CreatedUser = await _api.CreateUser(userDTO);

            if (CreatedUser != null)
            {
                OnUserCreated.Invoke();
            }
        }
    }
}