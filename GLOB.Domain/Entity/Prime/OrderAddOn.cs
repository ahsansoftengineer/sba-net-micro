using GLOB.Domain.Base;

namespace GLOB.Domain.Entity;
public class OrderAddOn : BaseEntity
{
  public ICollection<OrderBusiness> OrderBusiness { get; set; } = new List<OrderBusiness>();
}
