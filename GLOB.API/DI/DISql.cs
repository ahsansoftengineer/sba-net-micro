using GLOB.Infra.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using GLOB.Infra.UOW;
using GLOB.Domain.Projectz;

namespace GLOB.API.DI;
public static partial class DICommon
{
  public static void Config_Identity(this IServiceCollection srvc)
  {
    var builder = srvc.AddIdentityCore<TestApiUser>(q => q.User.RequireUniqueEmail = true);
    builder = new IdentityBuilder(
      builder.UserType,
      typeof(IdentityRole), srvc);

    builder
      .AddEntityFrameworkStores<DBCntxt>()
      .AddDefaultTokenProviders();
  }
  public static void Config_DB_SQL<TContext, TIUOW, TUOW>(this IServiceCollection srvc, IConfiguration config) 
    where TContext : DBCntxt
    where TIUOW : class, IUnitOfWorkz
    where TUOW : UnitOfWorkz, TIUOW

  {
    srvc.AddDbContext<TContext>(opt =>
    {
      string connStr = config.GetConnectionString("SqlConnection");
      opt.EnableSensitiveDataLogging(true);
      opt.UseSqlServer(connStr, sqlOptions =>
        {
          sqlOptions.EnableRetryOnFailure(
            maxRetryCount: 1,
            maxRetryDelay: TimeSpan.FromSeconds(3),
            errorNumbersToAdd: null
          );
        });
        opt.LogTo(Console.WriteLine, LogLevel.Information);
    });
    srvc.AddScoped<TIUOW, TUOW>();
  }
}