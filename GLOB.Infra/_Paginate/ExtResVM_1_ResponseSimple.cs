using System.Net;
using GLOB.Domain.Base;
using Microsoft.EntityFrameworkCore;

namespace GLOB.Infra.Helper;

public static partial class ExtResponse
{
  public static VMSingle<TEntity> ToExtVMSingle<TEntity>(this TEntity? item)
  where TEntity : class
  {
    return new () {
      Record = item,
      Status = HttpStatusCode.OK
    };
  }
  // Maybe this doesn't reqired in future
  public static VMList<TEntity> ToExtVMList<TEntity>(this IList<TEntity>? list)
  {
    return new() {
      Records = list ?? new List<TEntity>(),
      Status = HttpStatusCode.OK
    };
  }

  public static async Task<VMPaginate<T>> ToExtVMPaging<T>(
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