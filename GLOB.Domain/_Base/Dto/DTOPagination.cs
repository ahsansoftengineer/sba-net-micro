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
public class DtoPageReq<TDtoSearch>
{
  public List<string>? Include { get; set; }
  public int PageNo { get; set; } = 1;
  public int PageSize { get; set; } = 10;
  public TDtoSearch? Filter { get; set; }
  public Sort? Sort { get; set; }
}


public class DtoPageRes<T> 
{

  public List<T> Records { get; set; }
  public int Count { get; set; } = 0;
  public int PageSize { get; set; } = 10;
  public int PageNo { get; set; } = 1;
  public int TotalPages => (int)Math.Ceiling(Count / (double)PageSize);

  public bool HasPreviousPage => PageNo > 1 && TotalPages >= PageNo - 1;
  public bool HasNextPage => PageNo < TotalPages;
  public HttpStatusCode Status = HttpStatusCode.OK;

  // public DtoPageRes()
  // {
  //   throw new Exception("Don't use Empty Constructor!!!!");
  // }
  public DtoPageRes(DtoPageRes<T> data)
  {

    Records = data.Records;
    Count = data.Count;
    PageSize = data.PageSize;
    PageNo = PageNo;
  }

    public DtoPageRes()
    {
    }
}
