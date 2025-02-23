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

public class PaginateRequestFilter<TEntity, TDtoSearch>
{
  public int PageNo { get; set; } = 1;
  public int PageSize { get; set; } = 10;
  public bool IsMapped { get ; set; } = false;
  public TDtoSearch? Filter { get; set; }
  public Sort? Sort { get; set; }
  public List<string>? Include { get; set; }
}

public class BaseDtoPageRes<T>
{
  public List<T> Records { get; private set; }
  public List<DtoSelect> Options { get; private set; }
  public int Count { get; private set; } = 0;
  public int PageSize { get; private set; } = 10;
  public int PageNo { get; private set; } = 1;
  public int TotalPages => (int)Math.Ceiling(Count / (double)PageSize);

  public bool HasPreviousPage => PageNo > 1;
  public bool HasNextPage => PageNo < TotalPages;
  public HttpStatusCode Status = HttpStatusCode.OK;

  public BaseDtoPageRes(List<T> record, int count, int pageNo, int pageSize)
  {

    Records = record;
    Count = count;
    PageSize = pageSize;
    PageNo = pageNo;
  }
  public BaseDtoPageRes(List<DtoSelect> record, int count, int pageNo, int pageSize)
  {

    Options = record;
    Count = count;
    PageSize = pageSize;
    PageNo = pageNo;
  }
}