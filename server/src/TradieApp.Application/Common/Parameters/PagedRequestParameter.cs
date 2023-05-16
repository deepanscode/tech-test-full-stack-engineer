namespace TradieApp.Application.Common.Parameters;

public abstract class PagedRequestParameter
{
    private const int MaxPageSize = 100;
    private const int DefaultPageSize = 25;

    private int _pageNumber = 0;
    private int _pageSize = DefaultPageSize;

    public int PageNumber
    {
        get
        {
            return _pageNumber;
        }
        set
        {
            _pageNumber = value < 0 ? 0 : value;
        }
    }

    public int PageSize
    {
        get
        {
            return _pageSize;
        }
        set
        {
            _pageSize = value > MaxPageSize ? MaxPageSize : value;
        }
    }

    internal int Skip { get { return (_pageNumber > 0 ? _pageNumber -1 : 0) * _pageSize; } }
    internal int Take { get { return _pageSize; } }
}

