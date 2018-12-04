namespace Isarithm.Common.Domain
{
	public class Device
	{
		public string id { get; set; }
		public string model { get; set; }
		public long regDate { get; set; }
		public User owner { get; set; }
	}
}
