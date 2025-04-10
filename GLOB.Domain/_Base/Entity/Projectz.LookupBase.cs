namespace GLOB.Domain.Base;

public class ProjectzLookupzBase : EntityBase
{
  public virtual ICollection<ProjectzLookup>? ProjectzLookup { get; set; }
}