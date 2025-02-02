using GLOB.Apps.Common;
using GLOB.Domain.Entity;

namespace GLOB.Infra.Common;
public partial class UnitOfWorkz
{
  // Hierarchy
  public IRepoGenericz<TestEntity> TestEntitys => _testEntity ??= new RepoGenericz<TestEntity>(_context);
  public IRepoGenericz<TestParent> TestParents => _testParent ??= new RepoGenericz<TestParent>(_context);
  public IRepoGenericz<TestChild> TestChilds => _testChild ??= new RepoGenericz<TestChild>(_context);
  public IRepoGenericz<TestStatus> TestStatus => _testStatus ??= new RepoGenericz<TestStatus>(_context);


}