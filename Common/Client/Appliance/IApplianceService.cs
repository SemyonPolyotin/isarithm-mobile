using System;
using System.Threading.Tasks;
using Isarithm.Common.Client.Appliance.Model;
using Isarithm.Common.Client.Model;

namespace Isarithm.Common.Client.Appliance
{
    public interface IApplianceService
    {
        Task<Page<ModelResponse>> GetModelsAsync(int page = 0, int size = 25);
        Task<ModelResponse> GetModelAsync(Guid modelId);
    }
}