
using GLOB.Domain.Base;

namespace GLOB.Infra.Helper;
public static partial class RepoExtensionActions
{
  public static IQueryable<DtoSelect> ToExtMapping<T>(this IQueryable<T> source)
    where T : class, IEntityAlpha, IEntityStatus
  {
    Console.WriteLine("-->>>>>> Select Called");
    return source.Select(x => new DtoSelect
    {
      Id = x.Id,
      Name = x.Name,
      Status = x.Status
    });
  }
}
