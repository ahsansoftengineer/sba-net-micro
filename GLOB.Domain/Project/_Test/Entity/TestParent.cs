using GLOB.Domain.Base;

namespace GLOB.Domain.Projectz;
public class TestParent : EntityBase
{
  public virtual IList<TestChild>? TestChilds { get; set; }
}