namespace GLOB.Domain.Base;

public class ProjectzLookupBase : EntityBase
{
  public virtual ICollection<ProjectzLookup>? ProjectzLookup { get; set; }
}