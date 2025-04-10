using GLOB.Infra.Repo;
using GLOB.Domain.Projectz;
using GLOB.Domain.Base;

namespace GLOB.Infra.UOW_Projectz;
public partial class UOW_Infra : IUOW_Infra
{
  private IRepoGenericz<API_Infra_EntityTest>? _testInfra;
  private IRepoGenericz<ProjectzLookupzBase>? _projectzLookupzBase;
  private IRepoGenericz<ProjectzLookup>? _projectzLookup;

  
  public IRepoGenericz<API_Infra_EntityTest> TestInfras => _testInfra ??= new RepoGenericz<API_Infra_EntityTest>(_context);
  public IRepoGenericz<ProjectzLookupzBase> ProjectzLookupzBases => _projectzLookupzBase ??= new RepoGenericz<ProjectzLookupzBase>(_context);
  public IRepoGenericz<ProjectzLookup> ProjectzLookups => _projectzLookup ??= new RepoGenericz<ProjectzLookup>(_context);


}