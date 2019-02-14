using System;
using System.Threading.Tasks;
using Isarithm.Common.Client.Account.Model;
using Isarithm.Common.Client.Action.Model;
using Isarithm.Common.Client.Model;

namespace Isarithm.Common.Client.Action
{
    public interface IActionService
    {
        Task<Page<ActivityResponse>> GetActionsAsync(int page = 0, int size = 25);

        Task<Page<ActivityResponse>> GetActionsOfUserAsync(Guid userId, int page = 0, int size = 25);
        Task<UserResponse> CreateActionOfUserAsync(UserRequest user);
    }
}