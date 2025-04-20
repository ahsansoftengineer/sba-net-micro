using GLOB.Domain.Auth;
using GLOB.Infra.Repo;

namespace SBA.Projectz.Data;

public partial class UOW_Projectz
{

  public IRepoGenericz<RefreshToken> RefreshTokens => _RefreshToken ??= new RepoGenericz<RefreshToken>(_context);
}