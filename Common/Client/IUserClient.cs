using System.Threading.Tasks;
using Isarithm.Common.Client.Model;
using Isarithm.Common.Domain;

namespace Isarithm.Common.Client
{
	public interface IUserClient
	{
		Task<UserResponse> GetUserAsync(string userId);
		Task<Page<User>> GetUsersAsync(int page = 0, int size = 25);
		Task<UserResponse> CreateUserAsync(UserRequest user);
		Task<UserResponse> UpdateUserAsync(string userId, UserRequest userRequest);
		Task DeleteUserAsync(string id);

//		Task<Page<Device>> GetDevices(string deviceId, int page = 0, int size = 25);
//		Task<Page<Device>> CreateDevice(DeviceRequest deviceRequest);
//		Task<Page<Device>> UpdateDevice(string deviceId, DeviceRequest deviceRequest);
//		Task<Page<Device>> DeleteDevice(string deviceId);
	}
}