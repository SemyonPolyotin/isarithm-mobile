using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Isarithm.Common.Client.Auth.Model;
using Newtonsoft.Json;

namespace Isarithm.Common.Client.Auth
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _client;

        private const string AuthUrl = "http://auth.api.isarithm.ru";

        private static readonly Lazy<AuthService> _instance = new Lazy<AuthService>(() => new AuthService());
        
        private AuthService()
        {
            _client = new HttpClient();
        }
        
        public static AuthService Current
        {
            get { return _instance.Value; }
        }

        public async Task<UserResponse> CreateUserAsync(UserCredentialsRequest userCredentialsRequest)
        {
            var uri = new Uri($"{AuthUrl}/users");
            try
            {
                var userJson = JsonConvert.SerializeObject(userCredentialsRequest);
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

        public async Task<UserTokenResponse> CreateTokenAsync(UserCredentialsRequest userCredentialsRequest)
        {
            var uri = new Uri($"{AuthUrl}/token");
            try
            {
                var userJson = JsonConvert.SerializeObject(userCredentialsRequest);
                var content = new StringContent(userJson, Encoding.UTF8, "application/json");

                var response = await _client.PostAsync(uri, content).ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    var userTokenResponseJson = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    var userTokenResponse = JsonConvert.DeserializeObject<UserTokenResponse>(userTokenResponseJson);
                    return await Task.FromResult(userTokenResponse).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }

            return null;
        }

        public async Task DeleteTokenAsync(UserTokenRequest userTokenRequest)
        {
//            var uri = new Uri($"{AuthUrl}/token/refresh");
//            try
//            {
//                var userJson = JsonConvert.SerializeObject(userTokenRequest);
//                var content = new StringContent(userJson, Encoding.UTF8, "application/json");
//
//                var response = await _client.DeleteAsync(uri, content);
//                if (response.IsSuccessStatusCode)
//                {
//                    var userTokenResponseJson = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
//                    var userTokenResponse = JsonConvert.DeserializeObject<UserTokenResponse>(userTokenResponseJson);
//                    return await Task.FromResult(userTokenResponse).ConfigureAwait(false);
//                }
//            }
//            catch (Exception e)
//            {
//                Debug.WriteLine(e.Message);
//            }
        }

        public async Task<UserResponse> CheckTokenAsync(UserTokenRequest userTokenRequest)
        {
            var uri = new Uri($"{AuthUrl}/token/check");
            try
            {
                var userJson = JsonConvert.SerializeObject(userTokenRequest);
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

        public async Task<UserTokenResponse> RefreshTokenAsync(UserTokenRequest userTokenRequest)
        {
            var uri = new Uri($"{AuthUrl}/token/refresh");
            try
            {
                var userJson = JsonConvert.SerializeObject(userTokenRequest);
                var content = new StringContent(userJson, Encoding.UTF8, "application/json");

                var response = await _client.PostAsync(uri, content).ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    var userTokenResponseJson = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    var userTokenResponse = JsonConvert.DeserializeObject<UserTokenResponse>(userTokenResponseJson);
                    return await Task.FromResult(userTokenResponse).ConfigureAwait(false);
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