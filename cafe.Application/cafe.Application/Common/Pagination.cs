using cafe.Domain.Common;

namespace cafe.Application.Common
{
    public static class Pagination
    {
        public static PaginatedResult<ICollection<T>> ToPagition<T>(this ICollection<T> list, int pageNumber, int pageSize)
        {
            int currentPageNumber = (pageNumber - 1) * pageSize;
            var paginatedResult = list.Skip(currentPageNumber).Take(pageSize).ToList();
            return new PaginatedResult<ICollection<T>> { CurrentPage = currentPageNumber, TotalCount = list.Count, data = paginatedResult };
        }
    }
}

