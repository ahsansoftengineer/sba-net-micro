using System.Net;
using GLOB.Domain.Base;

namespace GLOB.Infra.Helper;
public static partial class ExtRes
{
    public static BaseVMSingle ToExtVMSingle<TEntity>(this TEntity? item)
    where TEntity : class //, IEntityBase
    {
        var vm = new BaseVMSingle()
        {
            Record = item ,
            Status = HttpStatusCode.OK
        };
        return vm;
    }
    public static BaseVMMulti<TEntity> ToExtVMMulti<TEntity>(this IQueryable<TEntity>? list)
    where TEntity : class //, IEntityBeta
    {
        var vm = new BaseVMMulti<TEntity>()
        {
            Records = list.ToList() ?? new List<TEntity>(),
            Status = HttpStatusCode.OK
        };
        return vm;
    }
    // Maybe this doesn't reqired in future
    public static BaseVMMulti<TEntity> ToExtVMMulti<TEntity>(this IList<TEntity>? list)
    // where TEntity : class //, IEntityBeta
    {
        var vm = new BaseVMMulti<TEntity>()
        {
            Records = list ?? new List<TEntity>(),
            Status = HttpStatusCode.OK
        };
        return vm;
    }
    public static BaseVMSelect ToExtVMSelect<TEntity>(this List<TEntity>? list)
    where TEntity : class, IEntityAlpha
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
            Name = x.Name
        }).ToList();
        vm.Records = result;
        return vm;
    }
}