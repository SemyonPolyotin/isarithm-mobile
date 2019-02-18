using System;
using System.Threading.Tasks;
using Isarithm.Common.Client.Account.Model;
using Isarithm.Common.Client.Action.Model;

namespace Isarithm.Common.Client.Action
{
    public interface IActionService
    {
        Task<Page<ActivityResponse>> GetActivitiesAsync(int page = 0, int size = 25);

        Task<Page<ActivityResponse>> GetActivitiesOfUserAsync(Guid userId, int page = 0, int size = 25);
        Task<UserResponse> CreateActivitiesOfUserAsync(UserRequest user);
    }
}