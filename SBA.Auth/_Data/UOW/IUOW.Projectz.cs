using GLOB.Domain.Auth;
using GLOB.Infra.Repo;
using GLOB.Infra.UOW_Projectz;

namespace SBA.Projectz.Data;

public interface IUOW_Projectz : IUOW_Infra
{
  IRepoGenericz<RefreshToken> RefreshTokens { get; }
}