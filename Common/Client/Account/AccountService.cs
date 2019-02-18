using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Isarithm.Common.Client.Account.Model;
using Isarithm.Common.Utility;
using Newtonsoft.Json;

namespace Isarithm.Common.Client.Account
{
    public class AccountService : IAccountService
    {
        private readonly HttpClient _client;

        private const string AccountUrl = "http://account.api.isarithm.ru";

        private static readonly Lazy<AccountService> _instance = new Lazy<AccountService>(() => new AccountService());

        private AccountService()
        {
            _client = new HttpClient();
        }

        public static AccountService Current
        {
            get { return _instance.Value; }
        }

        public async Task<Page<UserResponse>> GetUsersAsync(int page = 0, int size = 25)
        {
            var uri = new Uri($"{AccountUrl}/users/?page={page}&size={size}");
            try
            {
                var response = await _client.GetAsync(uri).ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    var usersResponse = JsonConvert.DeserializeObject<Page<UserResponse>>(content);
                    return await Task.FromResult(usersResponse).ConfigureAwait(false);
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

                var response = await _client.PostAsync(uri, content).ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    var userResponseJson = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    var userResponse = JsonConvert.DeserializeObject<UserResponse>(userResponseJson);
                    return await Task.FromResult(userResponse).ConfigureAwait(false);
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
            var uri = new Uri($"{AccountUrl}/users/{userId}");
            try
            {
                var response = await _client.GetAsync(uri).ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    var userResponseJson = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    var userResponse = JsonConvert.DeserializeObject<UserResponse>(userResponseJson);
                    return await Task.FromResult(userResponse).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
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

                var response = await _client.PatchAsync(uri, content).ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    var userResponseJson = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    var userResponse = JsonConvert.DeserializeObject<UserResponse>(userResponseJson);
                    return await Task.FromResult(userResponse).ConfigureAwait(false);
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
                var response = await _client.DeleteAsync(uri).ConfigureAwait(false);
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

        public async Task<Page<DeviceResponse>> GetDevicesOfUserAsync(Guid userId, int page = 0, int size = 25)
        {
            var uri = new Uri($"{AccountUrl}/users/{userId}/devices?page={page}&size={size}");
            try
            {
                var response = await _client.GetAsync(uri).ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    var devicesResponse = JsonConvert.DeserializeObject<Page<DeviceResponse>>(content);
                    return await Task.FromResult(devicesResponse).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }

            return null;
        }

        public async Task<DeviceResponse> CreateDeviceOfUserAsync(Guid userId, DeviceRequest deviceRequest)
        {
            var uri = new Uri($"{AccountUrl}/users/{userId}/devices");
            try
            {
                var userJson = JsonConvert.SerializeObject(deviceRequest);
                var content = new StringContent(userJson, Encoding.UTF8, "application/json");

                var response = await _client.PostAsync(uri, content).ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    var deviceResponseJson = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    var deviceResponse = JsonConvert.DeserializeObject<DeviceResponse>(deviceResponseJson);
                    return await Task.FromResult(deviceResponse).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }

            return null;
        }

        public async Task<DeviceResponse> UpdateDeviceOfUserAsync(Guid userId, int deviceId,
            DeviceRequest deviceRequest)
        {
            var uri = new Uri($"{AccountUrl}/users/{userId}/devices/{deviceId}");
            try
            {
                var userJson = JsonConvert.SerializeObject(deviceRequest);
                var content = new StringContent(userJson, Encoding.UTF8, "application/json");

                var response = await _client.PatchAsync(uri, content).ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    var deviceResponseJson = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    var deviceResponse = JsonConvert.DeserializeObject<DeviceResponse>(deviceResponseJson);
                    return await Task.FromResult(deviceResponse).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }

            return null;
        }

        public async Task DeleteDeviceOfUserAsync(Guid userId, int deviceId)
        {
            var uri = new Uri($"{AccountUrl}/users/{userId}/devices/{deviceId}");
            try
            {
                var response = await _client.DeleteAsync(uri).ConfigureAwait(false);
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

        public async Task<Page<DeviceResponse>> GetDevicesAsync(int page = 0, int size = 25)
        {
            var uri = new Uri($"{AccountUrl}/devices?page={page}&size={size}");
            try
            {
                var response = await _client.GetAsync(uri).ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    var devicesResponse = JsonConvert.DeserializeObject<Page<DeviceResponse>>(content);
                    return await Task.FromResult(devicesResponse).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }

            return null;
        }

        public async Task<DeviceResponse> GetDeviceAsync(int deviceId)
        {
            var uri = new Uri($"{AccountUrl}/devices/{deviceId}");
            try
            {
                var response = await _client.GetAsync(uri).ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    var deviceResponseJson = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    var deviceResponse = JsonConvert.DeserializeObject<DeviceResponse>(deviceResponseJson);
                    return await Task.FromResult(deviceResponse).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }

            return null;
        }
    }
}