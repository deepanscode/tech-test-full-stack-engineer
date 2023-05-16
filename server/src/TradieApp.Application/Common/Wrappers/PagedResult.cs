using System;
namespace TradieApp.Application.Common.Wrappers;

public class PagedResult<T>
{
    public T Data { get; private set; }
    public int TotalRecordCount { get; private set; }
    public int PageNumber { get; private set; }
    public int PageSize { get; private set; }

    public PagedResult(T data, int pageNumber, int pageSize, int totalRecordCount)
    {
        Data = data;
        TotalRecordCount = totalRecordCount;
        PageNumber = pageNumber;
        PageSize = pageSize;
    }
}

