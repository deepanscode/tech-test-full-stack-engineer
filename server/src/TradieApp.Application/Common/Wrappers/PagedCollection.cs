namespace TradieApp.Application.Common.Wrappers;

public class PagedCollection<T> : PagedResult<IReadOnlyCollection<T>>
{
    public PagedCollection(IReadOnlyCollection<T> data, int pageNumber, int pageSize, int totalRecordCount) : base(data, pageNumber, pageSize, totalRecordCount)
    {
    }
}

