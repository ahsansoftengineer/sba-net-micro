
using GLOB.Domain.Base;

namespace GLOB.Infra.Helper;
public static partial class RepoExtensionActions
{
  public static IQueryable<BaseDtoSelect> ToExtMapping<T>(this IQueryable<T> source)
    where T : class, IBetaEntity
  {
    return source.Select(x => new BaseDtoSelect
    {
      Id = x.Id ?? 0,
      Title = x.Title
    });
  }
}
