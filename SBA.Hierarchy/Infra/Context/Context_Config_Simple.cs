using GLOB.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace SBA.Hierarchy.Common;
public partial class AppDBContextProj
{
  private static void ConfigManyToOne(ModelBuilder mb)
  {
    mb.Entity<Systemz>()
      .HasOne(e => e.Org)
      .WithMany(e => e.Systemzs)
      .HasForeignKey(e => e.OrgId)
      .IsRequired(false);

    mb.Entity<City>()
      .HasOne(e => e.State)
      .WithMany(e => e.Citys)
      .HasForeignKey(e => e.StateId)
      .IsRequired(false);

    mb.Entity<LE>()
      .HasOne(e => e.BG)
      .WithMany(e => e.LEs)
      .HasForeignKey(e => e.BGId)
      .IsRequired(false);

    mb.Entity<OU>()
      .HasOne(e => e.LE)
      .WithMany(e => e.OUs)
      .HasForeignKey(e => e.LEId)
      .IsRequired(false);
    
    mb.Entity<SU>()
      .HasOne(e => e.OU)
      .WithMany(e => e.SUs)
      .HasForeignKey(e => e.OUId)
      .IsRequired(false);

   
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
