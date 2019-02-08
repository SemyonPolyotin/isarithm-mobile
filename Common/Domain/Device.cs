namespace Isarithm.Common.Domain
{
	public class Device
	{
		public string Id { get; set; }
		public string Model { get; set; }
		public long RegDate { get; set; }
		public User Owner { get; set; }
	}
}
