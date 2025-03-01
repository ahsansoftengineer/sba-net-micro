using GLOB.Infra.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using GLOB.Infra.UOW;
using GLOB.Domain.Projectz;
using GLOB.Domain.Auth;


namespace GLOB.API.DI;
public static partial class DICommon
{
  public static void Config_Identity(this IServiceCollection srvc)
  {
    var builder = srvc.AddIdentityCore<TestApiUser>(option =>
    {
      option.User.RequireUniqueEmail = true;
    });

    builder = new IdentityBuilder(
      builder.UserType,
      typeof(AuthRole), srvc);

    builder.Services.AddIdentity<AuthUser, AuthRole>()
        .AddEntityFrameworkStores<DBCntxtIdentity>()
        .AddDefaultTokenProviders();


    // // Configure Authentication
    // builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    //     .AddJwtBearer(options =>
    //     {
    //       options.RequireHttpsMetadata = false;
    //       options.SaveToken = true;
    //       options.TokenValidationParameters = new TokenValidationParameters
    //       {
    //         ValidateIssuerSigningKey = true,
    //         IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("YourSuperSecretKey")),
    //         ValidateIssuer = false,
    //         ValidateAudience = false
    //       };
    //     });


    builder.Services.AddAuthorization();
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