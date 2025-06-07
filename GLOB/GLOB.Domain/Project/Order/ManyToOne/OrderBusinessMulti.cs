using GLOB.Infra.Base;

namespace GLOB.Domain.Hierarchy;
public class OrderBusinessMulti : EntityBeta
{
  public ICollection<OrderBusiness> OrderBusiness { get; set; } = [];
}
