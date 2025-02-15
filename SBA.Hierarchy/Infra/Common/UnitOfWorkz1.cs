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
  private IRepoGenericz<Org>? _Orgs;
  private IRepoGenericz<Systemz>? _Systemz;
  private IRepoGenericz<State>? _State;
  private IRepoGenericz<Bank>? _Bank;
  private IRepoGenericz<Brand>? _Brand;
  private IRepoGenericz<Industry>? _Industry;
  private IRepoGenericz<Profession>? _Profession;
  private IRepoGenericz<BG>? _BG;
  private IRepoGenericz<LE>? _LE;
  private IRepoGenericz<OU>? _OU;
  private IRepoGenericz<SU>? _SU;

    
}