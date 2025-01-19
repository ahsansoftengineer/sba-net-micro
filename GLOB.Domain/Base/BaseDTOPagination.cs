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
public class BaseDtoPagination
{
  const int maxPageSize = 50;
  public int? PageNo { get; set; } = 1;
  private int pageSize = 10;
  public int PageSize
  {
    get
    {
      return pageSize;
    }
    set
    {
      pageSize = value > maxPageSize ? maxPageSize : value;
    }
  }
}
public class PaginateResponse<T> : BaseDtoPagination
{
  public List<T>? Records { get; set; }
  public int Count { get; set; }
  public HttpStatusCode Status { get; set; }
  // public bool HasNextPage { get; set; } //

}
public class PaginateRequestFilter<T, TDto> : BaseDtoPagination
  where T : class
{
  public TDto? Search { get; set; }
  public Sort? Sort { get; set; }
  public List<string>? includes { get; set; }
}