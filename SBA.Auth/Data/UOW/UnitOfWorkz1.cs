using GLOB.Apps.Common;
using GLOB.Domain.Projectz;
using GLOB.Infra.UOW;

namespace SBA.Projectz.Data;
public partial class UOW : UnitOfWorkz, IUOW
{
  public UOW(AppDBContextProj context): base(context) { }
  private IRepoGenericz<TestProj>? _testProj;

    
}