using HotelBooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HotelBooking.API
{
    public class ApiClient
    {
        private readonly HttpClient _http;

        public ApiClient(string baseUrl)
        {
            _http = new HttpClient()
            {
                BaseAddress = new Uri(baseUrl)
            };
        }

        public async Task<UserDTO?> CreateUser(UserCreateDTO userDTO)
        {
            var response = await _http.PostAsJsonAsync("user", userDTO);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<UserDTO>();
        }



        public async Task<bool> Login(LoginRequestDTO request)
        {
            var response = await _http.PostAsJsonAsync("login", request);
            
            return response.IsSuccessStatusCode;
        }


        public async Task<List<HotelDTO>?> GetHotels()
        {
            var response = await _http.GetAsync("hotels");

            if (response.StatusCode == HttpStatusCode.NoContent)
                return new List<HotelDTO>();

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<List<HotelDTO>>();
        }
    }
}