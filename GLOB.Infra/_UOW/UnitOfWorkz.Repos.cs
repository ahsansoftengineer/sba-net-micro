using GLOB.Infra.Repo;
using GLOB.Domain.Projectz;
using GLOB.Domain.Base;

namespace GLOB.Infra.UOW;
public partial class UnitOfWorkInfra : IUnitOfWorkInfra
{
  private IRepoGenericz<API_Infra_EntityTest>? _testInfra;
  private IRepoGenericz<ProjectzEntityLookupBase>? _projectzEntityLookupBase;
  private IRepoGenericz<ProjectzEntityLookup>? _projectzEntityLookup;

  
  public IRepoGenericz<API_Infra_EntityTest> TestInfras => _testInfra ??= new RepoGenericz<API_Infra_EntityTest>(_context);
  public IRepoGenericz<ProjectzEntityLookupBase> ProjectzEntityLookupBases => _projectzEntityLookupBase ??= new RepoGenericz<ProjectzEntityLookupBase>(_context);
  public IRepoGenericz<ProjectzEntityLookup> ProjectzEntityLookups => _projectzEntityLookup ??= new RepoGenericz<ProjectzEntityLookup>(_context);


}