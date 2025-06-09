namespace GLOB.Infra.Model.Base;

public class ProjectzLookupBase : EntityBase
{
  public virtual ICollection<ProjectzLookup>? ProjectzLookup { get; set; }
}