using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Isarithm.Common.Client.Model;
using Isarithm.Common.Domain;
using Isarithm.Common.Utility;
using Newtonsoft.Json;

namespace Isarithm.Common.Client
{
	public class UserClient : IUserClient
	{
		private readonly HttpClient _client;

		public UserClient()
		{
			_client = new HttpClient();
//			_client.MaxResponseContentBufferSize = 256000;
		}

		public async Task<UserResponse> GetUserAsync(string userId)
		{
//			const string restUrl = "http://isarithm.ru/api/users/{0}";
//			var uri = new Uri(string.Format(restUrl, userId));
			var uri = new Uri("http://www.mocky.io/v2/5c06452a3300004d00e81559");

			using (var response = await _client.GetAsync(uri))
			{
				if (response.IsSuccessStatusCode)
				{
					var content = await response.Content.ReadAsStringAsync();
					var userResponse = JsonConvert.DeserializeObject<UserResponse>(content);
					return userResponse;
				}
			}

			return null;
		}

		public async Task<Page<User>> GetUsersAsync(int page, int size)
		{
			const string restUrl = "http://isarithm.ru/api/users/?page={0}&size={1}";
			var uri = new Uri(string.Format(restUrl, page, size));

			try
			{
				var response = await _client.GetAsync(uri);
				if (response.IsSuccessStatusCode)
				{
					var content = await response.Content.ReadAsStringAsync();
					var usersResponse = JsonConvert.DeserializeObject<Page<User>>(content);
					return await Task.FromResult(usersResponse);
				}
			}
			catch (Exception e)
			{
				Debug.WriteLine(e);
			}

			return null;
		}

		public async Task<UserResponse> CreateUserAsync(UserRequest user)
		{
			const string restUrl = "http://isarithm.ru/api/users/";
			var uri = new Uri(restUrl);

			try
			{
				var userJson = JsonConvert.SerializeObject(user);
				var content = new StringContent(userJson, Encoding.UTF8, "application/json");

				var response = await _client.PostAsync(uri, content);
				if (response.IsSuccessStatusCode)
				{
					var userResponseJson = await response.Content.ReadAsStringAsync();
					var userResponse = JsonConvert.DeserializeObject<UserResponse>(userResponseJson);
					return await Task.FromResult(userResponse);
				}
			}
			catch (Exception e)
			{
				Debug.WriteLine(e);
			}

			return null;
		}

		public async Task<UserResponse> UpdateUserAsync(string userId, UserRequest userRequest)
		{
			const string restUrl = "http://isarithm.ru/api/users/{0}";
			var uri = new Uri(string.Format(restUrl, userId));

			try
			{
				var userJson = JsonConvert.SerializeObject(userRequest);
				var content = new StringContent(userJson, Encoding.UTF8, "application/json");

				var response = await _client.PatchAsync(uri, content);
				if (response.IsSuccessStatusCode)
				{
					var userResponseJson = await response.Content.ReadAsStringAsync();
					var userResponse = JsonConvert.DeserializeObject<UserResponse>(userResponseJson);
					return await Task.FromResult(userResponse);
				}
			}
			catch (Exception e)
			{
				Debug.WriteLine(e);
			}

			return null;
		}

		public async Task DeleteUserAsync(string id)
		{
			const string restUrl = "http://isarithm.ru/api/users/{0}";
			var uri = new Uri(string.Format(restUrl, id));

			try
			{
				var response = await _client.DeleteAsync(uri);

				if (!response.IsSuccessStatusCode)
				{
				}
				else
				{
					Debug.WriteLine(@"				TodoItem successfully deleted.");
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(@"				ERROR {0}", ex.Message);
			}
		}
	}
}