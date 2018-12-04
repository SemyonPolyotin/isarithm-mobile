using System.Collections.ObjectModel;
using Isarithm.Common.Domain;

namespace Isarithm.Common.ViewModel
{
	public class UserViewModel
	{
		public ObservableCollection<User> Users { get; } = new ObservableCollection<User>();
	}
}