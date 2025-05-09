using System.Net;
using GLOB.Domain.Base;
using Microsoft.EntityFrameworkCore;

namespace GLOB.Infra.Paginate;

public static partial class ExtResponse
{
  public static object ToExtVMSingle(this object? item)
  {
    return new {
      Record = item,
      Status = HttpStatusCode.OK
    };
  }
  public static object ToExtVMList(this object? list)
  {
    return new {
      Records = list,
      Status = HttpStatusCode.OK
    };
  }

  public static async Task<VMPaginate<T>> ToExtVMPage<T>(
    this IQueryable<T> source, VMPaginate<T> p
  )
  {
    if (p.PageNo < 1) p.PageNo = 1;
    if (p.PageSize < 1) p.PageSize = 10;
    if (p.PageSize > 50) p.PageSize = 50;

    p.Count = await source.CountAsync();
    
    var query = source.Skip((p.PageNo - 1) * p.PageSize)
                .Take(p.PageSize);

    p.Records = await query.ToListAsync();
    return p;
  }
}