using System.Net;

namespace GLOB.Domain.Base;

public enum Order
{
  Unspecified = -1,
  Ascending,
  Descending
}
public class Sort
{
  public string? By { get; set; }
  public Order? Order { get; set; } = Base.Order.Unspecified;
}

public class BaseDtoPageResConstruct<T>
{
  public List<T> Records { get; set; }
  public int Count { get; set; } = 0;
  public int PageSize { get; set; } = 10;
  public int PageNo { get; set; } = 1;
}

public class PaginateRequestFilter<TDtoSearch> : PaginateRequestFilterSelect<TDtoSearch>
{
  public List<string>? Include { get; set; }
}

public class PaginateRequestFilterSelect<TDtoSearch>
{
  public int PageNo { get; set; } = 1;
  public int PageSize { get; set; } = 10;
  public TDtoSearch? Filter { get; set; }
  public Sort? Sort { get; set; }
}

public class BaseDtoPageRes<T> : BaseDtoPageResConstruct<T>
{

  public int TotalPages => (int)Math.Ceiling(Count / (double)PageSize);

  public bool HasPreviousPage => PageNo > 1 && TotalPages >= PageNo - 1;
  public bool HasNextPage => PageNo < TotalPages;
  public HttpStatusCode Status = HttpStatusCode.OK;

  public BaseDtoPageRes()
  {
    throw new Exception("Don't use Empty Constructor!!!!");
  }
  public BaseDtoPageRes(BaseDtoPageResConstruct<T> data)
  {

    Records = data.Records;
    Count = data.Count;
    PageSize = data.PageSize;
    PageNo = PageNo;
  }
  // public BaseDtoPageRes(List<DtoSelect<TKey>> record, int count, int pageNo, int pageSize)
  // {

  //   Options = record;
  //   Count = count;
  //   PageSize = pageSize;
  //   PageNo = pageNo;
  // }
}
// public class BaseDtoPageRes<T> : BaseDtoPageRes<T, int> 
// {

// }