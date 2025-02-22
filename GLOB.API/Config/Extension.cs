using System.Net;
using GLOB.Domain.Base;

namespace GLOB.API.Config;
public static class Extension
{
    public static BaseVMMulti<TEntity> ToBaseVMMulti<TEntity>(this List<TEntity>? list)
    where TEntity : class, IBaseEntity
    {
        var vm = new BaseVMMulti<TEntity>()
        {
            Records = list ?? new List<TEntity>(),
            Status = HttpStatusCode.OK
        };
        return vm;
    }
    public static BaseVMSelect ToBaseVMSelect<TEntity>(this List<TEntity>? list)
    where TEntity : class, IBaseEntity
    {
        var vm = new BaseVMSelect()
        {
            Records = new List<BaseDtoSelect>(),
            Status = HttpStatusCode.OK
        };
        if (list == null) return vm;

        var result = list.Select(x => new BaseDtoSelect
        {
            Id = x.Id ?? 0,
            Title = x.Title
        }).ToList();
        vm.Records = result;
        return vm;
    }

    public static BaseVMSingle<TEntity> ToBaseDtoSingle<TEntity>(this TEntity? item)
    where TEntity : class, IBaseEntity
    {
        var vm = new BaseVMSingle<TEntity>()
        {
            Record = item ?? null,
            Status = HttpStatusCode.OK
        };
        return vm;
    }
}