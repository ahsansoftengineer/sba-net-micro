using GLOB.Domain.Base;

namespace GLOB.API.Config;
public static class Extension
{
    public static List<BaseDtoSelect> ToBaseDtoSelect<TEntity>(this List<TEntity>? list)
    where TEntity : class, IBaseEntity
    {
        if (list == null) return new List<BaseDtoSelect>();

        return list.Select(x => new BaseDtoSelect
        {
            Id = x.Id ?? 0,
            Title = x.Title
        }).ToList();
    }
}