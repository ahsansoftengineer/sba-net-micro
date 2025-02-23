using GLOB.Domain.Base;

namespace GLOB.Domain.Projectz;
public class TestParent : BaseEntity
{
  public virtual IList<TestChild>? TestChilds { get; set; }
}