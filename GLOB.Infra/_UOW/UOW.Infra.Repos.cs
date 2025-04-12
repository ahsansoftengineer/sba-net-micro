using GLOB.Infra.Repo;
using GLOB.Domain.Projectz;
using GLOB.Domain.Base;

namespace GLOB.Infra.UOW_Projectz;
public partial class UOW_Infra : IUOW_Infra
{
  private IRepoGenericz<API_Infra_EntityTest>? _testInfra;
  private IRepoGenericz<ProjectzLookupzzBase>? _ProjectzLookupzzBase;
  private IRepoGenericz<ProjectzLookupzz>? _ProjectzLookupzz;

  
  public IRepoGenericz<API_Infra_EntityTest> TestInfras => _testInfra ??= new RepoGenericz<API_Infra_EntityTest>(_context);
  public IRepoGenericz<ProjectzLookupzzBase> ProjectzLookupzzBases => _ProjectzLookupzzBase ??= new RepoGenericz<ProjectzLookupzzBase>(_context);
  public IRepoGenericz<ProjectzLookupzz> ProjectzLookupzzs => _ProjectzLookupzz ??= new RepoGenericz<ProjectzLookupzz>(_context);


}