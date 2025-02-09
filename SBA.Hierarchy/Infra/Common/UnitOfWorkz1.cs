using GLOB.Apps.Common;
using GLOB.Domain.Entity;
using GLOB.Infra.Common;
using SBA.Hierarchy.App;
using SBA.Hierarchy.Common;

namespace SBA.Hierarchy.Infra;
public partial class UOW : UnitOfWorkz, IUOW
{
  public UOW(AppDBContextProj context): base(context) { }
  private IRepoGenericz<TestProj>? _testProj;
}