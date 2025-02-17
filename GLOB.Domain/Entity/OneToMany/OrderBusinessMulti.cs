using GLOB.Domain.Base;

namespace GLOB.Domain.Entity;
public class OrderBusinessMulti : BetaEntity
{
  public ICollection<OrderBusiness> OrderBusiness { get; set; } = [];
}
