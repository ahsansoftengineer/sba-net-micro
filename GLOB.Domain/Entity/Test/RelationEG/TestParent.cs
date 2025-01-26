namespace GLOB.Domain.Entity;
public class TestParent : BaseEntity
{
  public virtual IList<TestChild>? TestChilds { get; set; }
}