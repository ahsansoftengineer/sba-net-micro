using GLOB.Infra.Repo;
using GLOB.Domain.Projectz;
using GLOB.Infra.UOW_Projectz;

namespace SBA.Projectz.Data;
public partial class UOW_Projectz : UOW_Infra, IUOW_Projectz
{
  public UOW_Projectz(ProjectzDBCntxt context): base(context) { }
  private IRepoGenericz<ProjectzEntityTest>? _testProj;    
}