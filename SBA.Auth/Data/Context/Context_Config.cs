using Microsoft.EntityFrameworkCore;


namespace SBA.Auth.Data;
public partial class AppDBContext : DbContext
{
  private static void AppDBContextConfig(ModelBuilder mb)
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

  //   mb.Entity<City>()
  //     .HasOne(e => e.State)
  //     .WithMany(e => e.Citys)
  //     .HasForeignKey(e => e.StateID)
  //     .IsRequired(false);

  //   mb.Entity<WalletHistory>()
  //     .HasOne(e => e.Wallet)
  //     .WithMany(e => e.WalletHistorys)
  //     .HasForeignKey(e => e.WalletID)
  //     .IsRequired(false);
  // }

}