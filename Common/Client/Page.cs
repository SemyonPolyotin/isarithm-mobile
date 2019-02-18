using System.Collections.Generic;
using Newtonsoft.Json;

namespace Isarithm.Common.Client
{
    public class Page<T>
    {
        [JsonProperty("content")]
        public List<T> Content;
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