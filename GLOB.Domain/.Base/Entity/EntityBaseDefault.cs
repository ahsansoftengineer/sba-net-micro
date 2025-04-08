using System.ComponentModel.DataAnnotations.Schema;

namespace GLOB.Domain.Base;

public abstract class EntityAlpha : EntityAlpha<int>, IEntityAlpha
{
}

public abstract class EntityBeta : EntityBeta<int>, IEntityBeta
{
}

public abstract class EntityBase : EntityBase<int>, IEntityBase
{
}