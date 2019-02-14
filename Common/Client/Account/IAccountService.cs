using System;
using System.Threading.Tasks;
using Isarithm.Common.Client.Account.Model;
using Isarithm.Common.Client.Model;
using Isarithm.Common.Domain;

namespace Isarithm.Common.Client.Account
{
    public interface IAccountService
    {
        Task<Page<UserResponse>> GetUsersAsync(int page = 0, int size = 25);
        Task<UserResponse> CreateUserAsync(UserRequest user);
        Task<UserResponse> GetUserAsync(Guid userId);
        Task<UserResponse> UpdateUserAsync(Guid userId, UserRequest userRequest);
        Task DeleteUserAsync(Guid userId);

        Task<Page<Device>> GetDevicesOfUserAsync(Guid userId, int page = 0, int size = 25);
        Task<Page<Device>> CreateDeviceOfUserAsync(Guid userId, DeviceRequest deviceRequest);
        Task<Page<Device>> UpdateDeviceOfUserAsync(Guid userId, int deviceId, DeviceRequest deviceRequest);
        Task DeleteDeviceOfUserAsync(Guid userId, int deviceId);

        Task<Page<Device>> GetDevicesAsync(int page = 0, int size = 0);
    }
}