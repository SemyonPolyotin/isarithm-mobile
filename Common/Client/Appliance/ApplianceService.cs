using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Isarithm.Common.Client.Appliance.Model;
using Newtonsoft.Json;

namespace Isarithm.Common.Client.Appliance
{
    public class ApplianceService : IApplianceService
    {
        private readonly HttpClient _client;

        private const string ApplianceUrl = "http://appliance.api.isarithm.ru/";

        private static readonly Lazy<ApplianceService> _instance =
            new Lazy<ApplianceService>(() => new ApplianceService());

        private ApplianceService()
        {
            _client = new HttpClient();
        }

        public static ApplianceService Current
        {
            get { return _instance.Value; }
        }

        public async Task<Page<ModelResponse>> GetModelsAsync(int page = 0, int size = 25)
        {
            var uri = new Uri($"{ApplianceUrl}/models?page={page}&size={size}");
            try
            {
                var response = await _client.GetAsync(uri).ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    var modelsResponseJson = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    var modelsResponse = JsonConvert.DeserializeObject<Page<ModelResponse>>(modelsResponseJson);
                    return await Task.FromResult(modelsResponse).ConfigureAwait(false);
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
            var uri = new Uri($"{ApplianceUrl}/models/by?id={modelId}");
            try
            {
                var response = await _client.GetAsync(uri).ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    var modelResponseJson = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    var modelResponse = JsonConvert.DeserializeObject<ModelResponse>(modelResponseJson);
                    return await Task.FromResult(modelResponse).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }

            return null;
        }
    }
}