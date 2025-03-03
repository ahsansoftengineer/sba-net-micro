using Microsoft.EntityFrameworkCore;

namespace GLOB.Infra.Context;
public partial class DBCntxt
{
  private static void EntityMappingConfig(ModelBuilder mb)
  {
    // ConfigOneToMany(mb);
  }

  // private static void ConfigOneToMany(ModelBuilder mb)
  // {
  //   mb.Entity<BankAccount>()
  //     .HasOne(e => e.Bank)
  //     .WithMany(e => e.BankAccount)
  //     .HasForeignKey(e => e.BankID)
  //     .IsRequired(false);
  // }
}