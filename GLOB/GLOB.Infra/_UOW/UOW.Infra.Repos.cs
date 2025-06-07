using GLOB.Infra.Repo;
using GLOB.Infra.Base;

namespace GLOB.Infra.UOW_Projectz;
public partial class UOW_Infra : IUOW_Infra
{
  private IRepoGenericz<ProjectzLookupBase>? _ProjectzLookupBase;
  private IRepoGenericz<ProjectzLookup>? _ProjectzLookup;

  
  public IRepoGenericz<ProjectzLookupBase> ProjectzLookupBases => _ProjectzLookupBase ??= new RepoGenericz<ProjectzLookupBase>(_context);
  public IRepoGenericz<ProjectzLookup> ProjectzLookups => _ProjectzLookup ??= new RepoGenericz<ProjectzLookup>(_context);


}