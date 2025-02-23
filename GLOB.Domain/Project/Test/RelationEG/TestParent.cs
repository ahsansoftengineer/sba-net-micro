using GLOB.Domain.Base;

namespace GLOB.Domain.Hierarchy;
public class TestParent : BaseEntity
{
  public virtual IList<TestChild>? TestChilds { get; set; }
}