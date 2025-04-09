using GLOB.Infra.Repo;
using GLOB.Domain.Projectz;
using GLOB.Infra.UOW;

namespace SBA.Projectz.Data;
public partial class UOW : UnitOfWorkInfra, IUOW
{
  public UOW(ProjectzDBCntxt context): base(context) { }
  private IRepoGenericz<ProjectzEntityTest>? _testProj;    
}