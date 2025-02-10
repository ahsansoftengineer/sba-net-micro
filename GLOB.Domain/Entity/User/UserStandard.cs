namespace GLOB.Domain.Entity;
public class UserStandard : UserExtend
{
  public ICollection<OrderStandard>? OrderStandards { get; set; } = null;
}
