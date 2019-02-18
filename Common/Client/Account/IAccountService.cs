using System;
using System.Threading.Tasks;
using Isarithm.Common.Client.Account.Model;

namespace Isarithm.Common.Client.Account
{
    public interface IAccountService
    {
        Task<Page<UserResponse>> GetUsersAsync(int page = 0, int size = 25);
        Task<UserResponse> CreateUserAsync(UserRequest user);
        Task<UserResponse> GetUserAsync(Guid userId);
        Task<UserResponse> UpdateUserAsync(Guid userId, UserRequest userRequest);
        Task DeleteUserAsync(Guid userId);

        Task<Page<DeviceResponse>> GetDevicesOfUserAsync(Guid userId, int page = 0, int size = 25);
        Task<DeviceResponse> CreateDeviceOfUserAsync(Guid userId, DeviceRequest deviceRequest);
        Task<DeviceResponse> UpdateDeviceOfUserAsync(Guid userId, int deviceId, DeviceRequest deviceRequest);
        Task DeleteDeviceOfUserAsync(Guid userId, int deviceId);

        Task<Page<DeviceResponse>> GetDevicesAsync(int page = 0, int size = 25);
    }
}