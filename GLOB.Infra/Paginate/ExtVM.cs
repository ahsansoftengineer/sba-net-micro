using System.Net;
using GLOB.Domain.Base;

namespace GLOB.Infra.Helper;
public static class Extension
{
    public static BaseVMMulti<TEntity> ToExtVMMulti<TEntity>(this List<TEntity>? list)
    where TEntity : class, IBaseEntity
    {
        var vm = new BaseVMMulti<TEntity>()
        {
            Records = list ?? new List<TEntity>(),
            Status = HttpStatusCode.OK
        };
        return vm;
    }
    public static BaseVMSelect ToExtVMSelect<TEntity>(this List<TEntity>? list)
    where TEntity : class, IBaseEntity
    {
        var vm = new BaseVMSelect()
        {
            Records = new List<DtoSelect>(),
            Status = HttpStatusCode.OK
        };
        if (list == null) return vm;

        var result = list.Select(x => new DtoSelect
        {
            Id = x.Id,
            Title = x.Title
        }).ToList();
        vm.Records = result;
        return vm;
    }

    public static BaseVMSingle<TEntity> ToExtVMSingle<TEntity>(this TEntity? item)
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