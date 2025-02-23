
using GLOB.Domain.Base;

namespace GLOB.Infra.Helper;
public static partial class RepoExtensionActions
{
  public static IQueryable<DtoSelect> ToExtMapping<T>(this IQueryable<T> source)
    where T : class, IBetaEntity
  {
    Console.WriteLine("-->>>>>> Select Called");
    return source.Select(x => new DtoSelect
    {
      Id = x.Id ?? 0,
      Title = x.Title,
      Status = x.Status
    });
  }
}
