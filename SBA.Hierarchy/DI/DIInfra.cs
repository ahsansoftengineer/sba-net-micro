using GLOB.Apps.Common;
using GLOB.Infra.Common;
using Microsoft.EntityFrameworkCore;

namespace GLOB.Infra;
public static class DI
{
  public static IServiceCollection AddInfra(
    this IServiceCollection services, 
    IConfiguration Configuration)
  {
    services
      //.AddAuth(Configuration)
      .AddPersistence(Configuration);
    return services;
  }
  public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration Configuration)
  {
    services.AddDbContext<AppDBContextz>(options =>
    {
      // TrustServerCertificate=true | Encrypt=false
      //options.UseSqlServer("SERVER=localhost;DATABASE=Donation;USER=sa;PASSWORD=asdf1234;Encrypt=false");
      options.UseSqlServer(Configuration.GetConnectionString("SqlConnection"));
    });
    // Transient Means Fresh Copy
    //services.AddSingleton<IGenericRepo, GenericRepo>(); // Done in UnitOfWork No Need
    services.AddTransient<IUnitOfWorkz, UnitOfWorkz>();
    //services.AddTransient<SignInManager<ApiUser>, SignInManager<ApiUser>>(); // Infrastructure
    //services.AddScoped<IOrgRepo, OrgRepo>(); //

    return services;
  }

  //public static IServiceCollection AddAuth(this IServiceCollection services, ConfigurationManager Configuration)
  //{
  //  var jwtSettings = new JwtSettings();
  //  Configuration.Bind(JwtSettings.SectionName, jwtSettings);

  //  //services.Configure<JwtSettings>(Configuration.GetSection(JwtSettings.SectionName));
  //  //Configuration[JwtSettings.Issuer] to access with above code

  //  // shorthand syntax for accessing configuration
  //  services.AddSingleton(Options.Create(jwtSettings));

  //  // 1. Interface are Coming From Application Layer
  //  // 2. Classes Coming From Infrastructure
  //  services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
  //  services
  //  .AddAuthentication(options =>
  //  {
  //    //  options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
  //    //  options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
  //    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
  //  })
  //  .AddJwtBearer(options =>
  //  {
  //    //options.SaveToken = true;
  //    //options.RequireHttpsMetadata = false;
  //    options.TokenValidationParameters = new TokenValidationParameters()
  //    {
  //    // Here we are saying what to Validate Issuer & Audience
  //    //ValidateIssuer = true,
  //    //ValidateAudience = true,
  //    //ValidateLifetime = true,

  //    // Here we are telling what is Issuer & Audience
  //    //ValidIssuer = jwtSettings.Issuer,
  //    //ValidAudience = jwtSettings.Audience,

  //    // To Help other component how to validate the signature of the Token
  //    ValidateIssuerSigningKey = true,
  //    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret)),

  //    // Swagger Causing Problem with it for time being we have to set Issuer & Audience like so
  //    ValidateIssuer = false,
  //    ValidateAudience = false,
  //    ValidAudience = "https://localhost:7228",
  //    ValidIssuer = "https://localhost:7228",

  //    };
  //  });
  //  return services;
  //}
}
