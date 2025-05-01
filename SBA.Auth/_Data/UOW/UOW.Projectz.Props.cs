using GLOB.Domain.Auth;
using GLOB.Infra.Repo;
using GLOB.Infra.UOW_Projectz;

namespace SBA.Projectz.Data;
public partial class UOW_Projectz : UOW_Infra, IUOW_Projectz
{
  public UOW_Projectz(DBCtxProjectz context): base(context) { }
  private IRepoGenericz<RefreshToken>? _RefreshToken;
}