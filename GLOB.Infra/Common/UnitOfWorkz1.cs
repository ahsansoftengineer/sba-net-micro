using GLOB.Apps.Common;
using GLOB.Domain.Entity;

namespace GLOB.Infra.Common;
public partial class UnitOfWorkz
{
  // Test
  private IRepoGenericz<TestEntity>? _testEntity;
  private IRepoGenericz<TestParent>? _testParent;
  private IRepoGenericz<TestChild>? _testChild;
  private IRepoGenericz<TestStatus>? _testStatus;
}