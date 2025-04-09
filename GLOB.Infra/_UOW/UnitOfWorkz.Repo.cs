using GLOB.Infra.Repo;
using GLOB.Domain.Projectz;

namespace GLOB.Infra.UOW;
public partial class UnitOfWorkInfra 
{
  private IRepoGenericz<API_Infra_EntityTest>? _testInfra;
  public IRepoGenericz<API_Infra_EntityTest> TestInfras => _testInfra ??= new RepoGenericz<API_Infra_EntityTest>(_context);

  // public IRepoGenericz<TestParent> TestParents => _testParent ??= new RepoGenericz<TestParent>(_context);
  // public IRepoGenericz<TestChild> TestChilds => _testChild ??= new RepoGenericz<TestChild>(_context);
  // public IRepoGenericz<TestStatus> TestStatus => _testStatus ??= new RepoGenericz<TestStatus>(_context);

}