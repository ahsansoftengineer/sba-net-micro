// using GLOB.Infra.Repo;
// using GLOB.Infra.Repo;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.Extensions.Configuration;
// using Microsoft.Extensions.DependencyInjection;

// namespace GLOB.Infra;
// public static class DI
// {
//   public static IServiceCollection AddInfra(this IServiceCollection srvc, IConfiguration Configuration)
//   {
//     srvc
//       //.AddAuth(Configuration)
//       .AddPersistence(Configuration);
//     return srvc;
//   }
//   public static IServiceCollection AddPersistence(this IServiceCollection srvc, IConfiguration Configuration)
//   {
//     srvc.AddDbContext<DBCntxt>(options =>
//     {
//       // TrustServerCertificate=true | Encrypt=false
//       //options.UseSqlServer("SERVER=localhost;DATABASE=Donation;USER=sa;PASSWORD=asdf1234;Encrypt=false");
//       options.UseSqlServer(Configuration.GetConnectionString("SqlConnection"));
//     });
//     // Transient Means Fresh Copy
//     //srvc.AddSingleton<IGenericRepo, GenericRepo>(); // Done in UnitOfWork No Need
//     srvc.AddTransient<IUnitOfWorkz, UnitOfWorkz>();
//     //srvc.AddTransient<SignInManager<ApiUser>, SignInManager<ApiUser>>(); // Infrastructure
//     //srvc.AddScoped<IOrgRepo, OrgRepo>(); //

//     return srvc;
//   }

//   //public static IServiceCollection AddAuth(this IServiceCollection srvc, ConfigurationManager Configuration)
//   //{
//   //  var jwtSettings = new JwtSettings();
//   //  Configuration.Bind(JwtSettings.SectionName, jwtSettings);

//   //  //srvc.Configure<JwtSettings>(Configuration.GetSection(JwtSettings.SectionName));
//   //  //Configuration[JwtSettings.Issuer] to access with above code

//   //  // shorthand syntax for accessing configuration
//   //  srvc.AddSingleton(Options.Create(jwtSettings));

//   //  // 1. Interface are Coming From Application Layer
//   //  // 2. Classes Coming From Infrastructure
//   //  srvc.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
//   //  srvc
//   //  .AddAuthentication(options =>
//   //  {
//   //    //  options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//   //    //  options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//   //    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
//   //  })
//   //  .AddJwtBearer(options =>
//   //  {
//   //    //options.SaveToken = true;
//   //    //options.RequireHttpsMetadata = false;
//   //    options.TokenValidationParameters = new TokenValidationParameters()
//   //    {
//   //    // Here we are saying what to Validate Issuer & Audience
//   //    //ValidateIssuer = true,
//   //    //ValidateAudience = true,
//   //    //ValidateLifetime = true,

//   //    // Here we are telling what is Issuer & Audience
//   //    //ValidIssuer = jwtSettings.Issuer,
//   //    //ValidAudience = jwtSettings.Audience,

//   //    // To Help other component how to validate the signature of the Token
//   //    ValidateIssuerSigningKey = true,
//   //    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret)),

//   //    // Swagger Causing Problem with it for time being we have to set Issuer & Audience like so
//   //    ValidateIssuer = false,
//   //    ValidateAudience = false,
//   //    ValidAudience = "https://localhost:7228",
//   //    ValidIssuer = "https://localhost:7228",

//   //    };
//   //  });
//   //  return srvc;
//   //}
// }
