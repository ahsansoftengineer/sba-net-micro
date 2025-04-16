using System.Net;
using GLOB.Domain.Base;

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
}