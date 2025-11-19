using HotelBooking.API;
using HotelBooking.Models;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HotelBooking.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private string _email;
        private string _password;
        private string _errorMessage;


        public string Email
        {
            get => _email;
            set
            {
                if (_email != value)
                {
                    _email = value;
                    OnPropertyChanged(nameof(Email));
                    OnPropertyChanged(nameof(CanLogin));
                }
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged(nameof(Password));
                    OnPropertyChanged(nameof(CanLogin));
                }
            }
        }

        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                if (_errorMessage != value)
                {
                    _errorMessage = value;
                    OnPropertyChanged(nameof(ErrorMessage));
                }
            }
        }


        public bool IsPasswordValid => !string.IsNullOrEmpty(Password) && Password.Length > 8;
        public bool IsEmailValid => !string.IsNullOrEmpty(Email) && Regex.IsMatch(Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");

        public bool CanLogin => IsPasswordValid && IsEmailValid;


        private readonly ApiClient _api;
        
        public Action? OnLoginSuccess {  get; set; }

        public ReactiveCommand<Unit, Unit> LoginCommand { get; }

        public LoginViewModel(ApiClient api)
        {
            _api = api;
            LoginCommand = ReactiveCommand.CreateFromTask(Login);
        }

        private async Task Login()
        {
            var loginRequest = new LoginRequestDTO
            {
                Email = Email,
                Password = Password
            };

            bool success = await _api.Login(loginRequest);

            if (success)
            {
                OnLoginSuccess?.Invoke();
            }
            else
            {
                ErrorMessage = "Invalid email or password";
            }
        }
    }
}