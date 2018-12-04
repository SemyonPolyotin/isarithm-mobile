using Newtonsoft.Json;

namespace Isarithm.Common.Client.Model
{
	public class UserResponse
	{
		[JsonProperty("id")]
		public string Id;
		[JsonProperty("username")]
		public string Username;
		[JsonProperty("firstname")]
		public string Firstname;
		[JsonProperty("surname")]
		public string Surname;
		[JsonProperty("email")]
		public string Email;
		[JsonProperty("regDate")]
		public string RegDate;
		[JsonProperty("bio")]
		public string Bio;
		[JsonProperty("avatar")]
		public string Avatar;
	}
}