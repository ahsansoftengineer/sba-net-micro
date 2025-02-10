
namespace GLOB.Domain.Entity;
public class OrderBusinessMulti : BaseBaseEntity
{
  public ICollection<OrderBusiness> OrderBusiness { get; set; } = [];
}
