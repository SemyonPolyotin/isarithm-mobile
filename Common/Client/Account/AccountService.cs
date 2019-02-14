using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Isarithm.Common.Client.Account.Model;
using Isarithm.Common.Client.Model;
using Isarithm.Common.Domain;
using Isarithm.Common.Utility;
using Newtonsoft.Json;

namespace Isarithm.Common.Client.Account
{
    public class AccountService : IAccountService
    {
        private readonly HttpClient _client;

        private const string AccountUrl = "http://account.api.isarithm.ru";
        
        public AccountService()
        {
            _client = new HttpClient();
        }

        public async Task<Page<UserResponse>> GetUsersAsync(int page = 0, int size = 25)
        {
            var uri = new Uri($"{AccountUrl}/users/?page={page}&size={size}");
            try
            {
                var response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var usersResponse = JsonConvert.DeserializeObject<Page<UserResponse>>(content);
                    return await Task.FromResult(usersResponse);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return null;
        }

        public async Task<UserResponse> CreateUserAsync(UserRequest user)
        {
            var uri = new Uri($"{AccountUrl}/users");
            try
            {
                var userJson = JsonConvert.SerializeObject(user);
                var content = new StringContent(userJson, Encoding.UTF8, "application/json");

                var response = await _client.PostAsync(uri, content);
                if (response.IsSuccessStatusCode)
                {
                    var userResponseJson = await response.Content.ReadAsStringAsync();
                    var userResponse = JsonConvert.DeserializeObject<UserResponse>(userResponseJson);
                    return await Task.FromResult(userResponse);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return null;
        }

        public async Task<UserResponse> GetUserAsync(Guid userId)
        {
            var uri = new Uri($"{AccountUrl}/users/${userId}");
            using (var response = await _client.GetAsync(uri))
            {
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var userResponse = JsonConvert.DeserializeObject<UserResponse>(content);
                    return userResponse;
                }
            }
            return null;
        }

        public async Task<UserResponse> UpdateUserAsync(Guid userId, UserRequest userRequest)
        {
            var uri = new Uri($"{AccountUrl}/users");
            try
            {
                var userJson = JsonConvert.SerializeObject(userRequest);
                var content = new StringContent(userJson, Encoding.UTF8, "application/json");

                var response = await _client.PatchAsync(uri, content);
                if (response.IsSuccessStatusCode)
                {
                    var userResponseJson = await response.Content.ReadAsStringAsync();
                    var userResponse = JsonConvert.DeserializeObject<UserResponse>(userResponseJson);
                    return await Task.FromResult(userResponse);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return null;
        }

        public async Task DeleteUserAsync(Guid userId)
        {
            var uri = new Uri($"{AccountUrl}/users/{userId}");
            try
            {
                var response = await _client.DeleteAsync(uri);

                if (!response.IsSuccessStatusCode)
                {
                    Debug.WriteLine("Deleting user failed");
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }

        public Task<Page<Device>> GetDevicesOfUserAsync(Guid userId, int page = 0, int size = 25)
        {
            throw new NotImplementedException();
        }

        public Task<Page<Device>> CreateDeviceOfUserAsync(Guid userId, DeviceRequest deviceRequest)
        {
            throw new NotImplementedException();
        }

        public Task<Page<Device>> UpdateDeviceOfUserAsync(Guid userId, int deviceId, DeviceRequest deviceRequest)
        {
            throw new NotImplementedException();
        }

        public Task DeleteDeviceOfUserAsync(Guid userId, int deviceId)
        {
            throw new NotImplementedException();
        }

        public Task<Page<Device>> GetDevicesAsync(int page = 0, int size = 0)
        {
            throw new NotImplementedException();
        }
    }
}