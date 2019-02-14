using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Isarithm.Common.Client.Appliance.Model;
using Isarithm.Common.Client.Model;
using Newtonsoft.Json;

namespace Isarithm.Common.Client.Appliance
{
    public class ApplianceService : IApplianceService
    {
        private readonly HttpClient _client;

        private const string ApplianceUrl = "http://appliance.api.isarithm.ru/";

        public ApplianceService(HttpClient client)
        {
            _client = client;
        }

        public async Task<Page<ModelResponse>> GetModelsAsync(int page = 0, int size = 25)
        {
            var uri = new Uri($"{ApplianceUrl}/models?page={page}&size={size}");
            try
            {
                var response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var activityResponse = JsonConvert.DeserializeObject<Page<ModelResponse>>(content);
                    return await Task.FromResult(activityResponse);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }

            return null;
        }

        public async Task<ModelResponse> GetModelAsync(Guid modelId)
        {
            var uri = new Uri($"{ApplianceUrl}/models/${modelId}");
            using (var response = await _client.GetAsync(uri))
            {
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var userResponse = JsonConvert.DeserializeObject<ModelResponse>(content);
                    return userResponse;
                }
            }

            return null;
        }
    }
}