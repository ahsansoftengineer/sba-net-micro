using GLOB.Infra.Repo;
using GLOB.Domain.Projectz;
using GLOB.Infra.UOW;

namespace SBA.Projectz.Data;
public partial class UOW : UnitOfWorkz, IUOW
{
  public UOW(DBCntxtProj context): base(context) { }
  private IRepoGenericz<TestProj>? _testProj;    
}