using GLOB.Infra.Repo;
using GLOB.Domain.Projectz;
using GLOB.Domain.Base;

namespace GLOB.Infra.UOW_Projectz;
public partial class UOW_Infra : IUOW_Infra
{
  private IRepoGenericz<API_Infra_EntityTest>? _testInfra;
  private IRepoGenericz<ProjectzLookupBase>? _ProjectzLookupBase;
  private IRepoGenericz<ProjectzLookup>? _ProjectzLookup;

  
  public IRepoGenericz<API_Infra_EntityTest> TestInfras => _testInfra ??= new RepoGenericz<API_Infra_EntityTest>(_context);
  public IRepoGenericz<ProjectzLookupBase> ProjectzLookupBases => _ProjectzLookupBase ??= new RepoGenericz<ProjectzLookupBase>(_context);
  public IRepoGenericz<ProjectzLookup> ProjectzLookups => _ProjectzLookup ??= new RepoGenericz<ProjectzLookup>(_context);


}