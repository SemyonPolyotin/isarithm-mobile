using System.Collections.Generic;

namespace Isarithm.Common.Client.Model
{
	public class Page<T>
	{
		List<T> content;
		Pageable pageable;
		bool last;
		int totalPages;
		int totalElements;
		Sort sort;
		int number;
		int numberOfElements;
		bool first;
		int size;
	}

	public class Pageable
	{
		private Sort sort;
		int pageSize;
		int pageNumber;
		int offset;
		bool paged;
		bool unpaged;
	}

	public class Sort
	{
		bool unsorted;
		bool sorted;
	}
}