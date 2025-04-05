
using GLOB.Domain.Base;

namespace GLOB.Infra.Helper;
public static partial class RepoExtensionActions
{
  public static IQueryable<DtoSelect> ToExtMapSelect<T>(this IQueryable<T> source)
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
  public static IQueryable<DtoSelectStrg> ToExtMapSelectStrg<T>(this IQueryable<T> source)
    where T : class, IEntityAlphaStrg, IEntityStatus
  {
    Console.WriteLine("-->>>>>> Select Called");
    return source.Select(x => new DtoSelectStrg
    {
      Id = x.Id,
      Name = x.Name,
      Status = x.Status
    });
  }
}
