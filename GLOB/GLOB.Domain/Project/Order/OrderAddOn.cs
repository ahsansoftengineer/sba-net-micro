using GLOB.Infra.Model.Base;

namespace GLOB.Domain.Hierarchy;
public class OrderAddOn : EntityBase
{
  public ICollection<OrderBusiness> OrderBusiness { get; set; } = new List<OrderBusiness>();
}
