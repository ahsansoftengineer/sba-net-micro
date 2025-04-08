namespace GLOB.Domain.Base;

// Short Entity Docs
// To Categorize the Short Entity of Different Types (Gender [Male, Female]), (Status [Active, Disable]), etc..
// Short Entity Recomended for (Enums, Constants)
// The Short Entity Should not Depend on Other Entity
// Other Entities can Depend on Short Entity (Employee, Etc)
// If The Entity Has the Fixed Size wont Change in the Years (Use Short Entity)
// Cache the Short Entity By Parent
// EntityShort/Gender/
// EntityShort/Status/
// EntityShort/StatusPay/
// EntityShort/StatusOrder/
public abstract class EntityShortParent : EntityBase
{
    
}

public abstract class EntityShort : EntityBase
{
  public string KeyIdentity { get; set; }
  public int? EntityShortParentId { get; set; }
  public virtual EntityShortParent? EntityShortParent { get; set; }
}
