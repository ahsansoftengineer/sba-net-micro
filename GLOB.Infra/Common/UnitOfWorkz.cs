using GLOB.Apps.Common;
using GLOB.Domain.Base;
using GLOB.Domain.Entity;

namespace GLOB.Infra.Common;
public partial class UnitOfWorkz 
{
  private IRepoGenericz<TestInfra>? _testInfra;
  public IRepoGenericz<TestInfra> TestInfras => _testInfra ??= new RepoGenericz<TestInfra>(_context);

  // public IRepoGenericz<TestParent> TestParents => _testParent ??= new RepoGenericz<TestParent>(_context);
  // public IRepoGenericz<TestChild> TestChilds => _testChild ??= new RepoGenericz<TestChild>(_context);
  // public IRepoGenericz<TestStatus> TestStatus => _testStatus ??= new RepoGenericz<TestStatus>(_context);

}