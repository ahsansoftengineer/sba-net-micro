using GLOB.Domain.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GLOB.Infra.Context.Auth;
public partial class DBCntxtIdentity : IdentityDbContext<UserInfra, IdentityRole, string>
{
  public DBCntxtIdentity(DbContextOptions options) : base(options) { }

  protected override void OnModelCreating(ModelBuilder mb)
  {
    base.OnModelCreating(mb);
  }
}
