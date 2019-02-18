using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Isarithm.Common.Client.Account.Model;
using Isarithm.Common.Client.Action.Model;
using Newtonsoft.Json;

namespace Isarithm.Common.Client.Action
{
    public class ActionService : IActionService
    {
        private readonly HttpClient _client;

        private const string AccountUrl = "http://action.api.isarithm.ru";

        private static readonly Lazy<ActionService> _instance = new Lazy<ActionService>(() => new ActionService());

        private ActionService()
        {
            _client = new HttpClient();
        }

        public async Task<Page<ActivityResponse>> GetActivitiesAsync(int page = 0, int size = 25)
        {
            var uri = new Uri($"{AccountUrl}/activities?page={page}&size={size}");
            try
            {
                var response = await _client.GetAsync(uri).ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    var activityResponse = JsonConvert.DeserializeObject<Page<ActivityResponse>>(content);
                    return await Task.FromResult(activityResponse).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }

            return null;
        }

        public async Task<Page<ActivityResponse>> GetActivitiesOfUserAsync(Guid userId, int page = 0, int size = 25)
        {
            throw new NotImplementedException();
        }

        public async Task<UserResponse> CreateActivitiesOfUserAsync(UserRequest user)
        {
            throw new NotImplementedException();
        }
    }
}