using GLOB.Domain.Base;

namespace GLOB.Domain.Hierarchy;
public class OrderBusinessMulti : BetaEntity
{
  public ICollection<OrderBusiness> OrderBusiness { get; set; } = [];
}
