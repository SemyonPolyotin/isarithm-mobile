using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Isarithm.Common.Client.Account.Model;
using Isarithm.Common.Client.Action.Model;
using Isarithm.Common.Client.Model;
using Newtonsoft.Json;

namespace Isarithm.Common.Client.Action
{
    public class ActionService : IActionService
    {
        private readonly HttpClient _client;

        private const string AccountUrl = "http://action.api.isarithm.ru";

        public ActionService(HttpClient client)
        {
            _client = client;
        }

        public async Task<Page<ActivityResponse>> GetActionsAsync(int page = 0, int size = 25)
        {
            var uri = new Uri($"{AccountUrl}/actions?page={page}&size={size}");
            try
            {
                var response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var activityResponse = JsonConvert.DeserializeObject<Page<ActivityResponse>>(content);
                    return await Task.FromResult(activityResponse);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }

            return null;
        }

        public async Task<Page<ActivityResponse>> GetActionsOfUserAsync(Guid userId, int page = 0, int size = 25)
        {
            throw new NotImplementedException();
        }

        public async Task<UserResponse> CreateActionOfUserAsync(UserRequest user)
        {
            throw new NotImplementedException();
        }
    }
}