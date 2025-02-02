using GLOB.Domain.Entity;
using GLOB.Infra.Common;
using GLOB.Infra.Helper;
using Microsoft.EntityFrameworkCore;

namespace GLOB.Infra.Seed;
public static class DI
{
  public static ModelBuilder AddInitialEntityData(this ModelBuilder mb)
  {
    // mb.ApplyConfiguration(new RoleConfig());
    mb.ApplyConfiguration(new CommonStatusConfigz<TestStatus>());
    mb.ApplyConfiguration(new CommonConfigz<TestParent>());
    mb.SeedTestChild();
    return mb;
  }
}