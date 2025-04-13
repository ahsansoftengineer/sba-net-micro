using GLOB.Infra.UOW_Projectz;

namespace SBA.Projectz.Data;
public partial class UOW_Projectz : UOW_Infra, IUOW_Projectz
{
  public UOW_Projectz(ProjectzDBCntxt context): base(context) { }
}