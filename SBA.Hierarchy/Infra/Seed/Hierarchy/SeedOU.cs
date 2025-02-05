using GLOB.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using SBA.Hierarchy.Infra;

namespace GLOB.Proj.Seed;
public static partial class Seeder
{
    public static void SeedOU(this AppDBContextProj context)
    {
        if (!context.OUs.Any(x => x.Id > 0))
        {
            Console.WriteLine("--> Seeding Data OU (Context)");
            context.OUs.AddRange(DataOU);
            context.SaveChanges();
        }
    }
    public static void SeedOU(this ModelBuilder builder)
    {
        Console.WriteLine("--> Seeding Data OU (ModelBuilder)");
        builder.Entity<OU>().HasData(DataOU);
    }
    public static List<OU> DataOU = [
      new OU
        {
            Id = 1,
            Title = "OU 1",
            Desc = "OU 1 Desc",
            LEId = 1,
            Law = "Ahsan",
            Address = "Korangi",
            Deposit = "3500",
            LogoImg = "LogoImg.jpg",
            TopImg = "TopImg.jpg",
            WarningImg = "WarningImg.jpg",
            FooterImg = "FooterImg.jpg"
        },
    new OU
    {
        Id = 2,
        Title = "OU 2",
        Desc = "OU 2 Desc",
        LEId = 2,
        Law = "Ahsan",
        Address = "Korangi",
        Deposit = "3500",
        LogoImg = "LogoImg.jpg",
        TopImg = "TopImg.jpg",
        WarningImg = "WarningImg.jpg",
        FooterImg = "FooterImg.jpg"
    },
    new OU
    {
        Id = 3,
        Title = "OU 3",
        Desc = "OU 3 Desc",
        LEId = 2,
        Law = "Ahsan",
        Address = "Korangi",
        Deposit = "3500",
        LogoImg = "LogoImg.jpg",
        TopImg = "TopImg.jpg",
        WarningImg = "WarningImg.jpg",
        FooterImg = "FooterImg.jpg"
    }
    ];

}