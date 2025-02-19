using System.Net;
using GLOB.Domain.Enums;

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

public class PaginateRequestFilter<TEntity, TDto>
{
  public int PageNo { get; set;} = 1;
  public int PageSize { get; set;} = 10;
  public TDto? Filter { get; set; }
  public Sort? Sort { get; set; }
  public List<string>? includes { get; set; }
}

public class PaginateResponse<T>
{
  public List<T> Records { get; private set; }
  public int Count { get; private set; }
  public int PageSize { get; private set; }
  public int PageNo { get; private set; }
  public int TotalPages => (int)Math.Ceiling(Count / (double)PageSize);

  public bool HasPreviousPage => PageNo > 1;
  public bool HasNextPage => PageNo < TotalPages;
  public HttpStatusCode Status = HttpStatusCode.OK;

  public PaginateResponse(List<T> record, int count, int pageNo, int pageSize)
  {
    
    Records = record;
    Count = count;
    PageSize = pageSize;
    PageNo = pageNo;
  }
}