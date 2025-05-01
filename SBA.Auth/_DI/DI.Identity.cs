// using System.Text;
// using GLOB.Infra.Data.Auth;
// using Microsoft.AspNetCore.Authentication.JwtBearer;
// using Microsoft.AspNetCore.Identity;
// using Microsoft.Extensions.Options;
// using Microsoft.IdentityModel.Tokens;

// namespace SBA.Projectz.DI;
// public static partial class Projectz_DI
// {
//   public static void AddAuth(this IServiceCollection srvc, ConfigurationManager Configuration)
//   {
//     var jwtSettings = new JwtSettings();
//     Configuration.Bind(JwtSettings.SectionName, jwtSettings);

//     srvc.Configure<JwtSettings>(Configuration.GetSection(JwtSettings.SectionName));
//     // Configuration[JwtSettings.Issuer] to access with above code

//     // shorthand syntax for accessing configuration

//     srvc.AddSingleton(Options.Create(jwtSettings));

//     // 1.Interface are Coming From Application Layer
//     // 2.Classes Coming From Infrastructure

//     srvc.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
//     srvc.AddAuthentication(options =>
//     {
//       options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//       options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//       options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
//     })
//     .AddJwtBearer(options =>
//     {
//       options.SaveToken = true;
//       options.RequireHttpsMetadata = false;
//       options.TokenValidationParameters = new TokenValidationParameters()
//       {
//         //  Here we are saying what to Validate Issuer & Audience
//         //  ValidateIssuer = true,
//         //  ValidateAudience = true,
//         ValidateLifetime = true,

//         //  Here we are telling what is Issuer & Audience
//         ValidIssuer = jwtSettings.Issuer,
//         ValidAudience = jwtSettings.Audience,

//         //  To Help other component how to validate the signature of the Token
//         ValidateIssuerSigningKey = true,
//         IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey)),

//         //  Swagger Causing Problem with it for time being we have to set Issuer & Audience like so
//         // ValidateIssuer = false,
//         // ValidateAudience = false,
//         // ValidAudience = "https://localhost:7228",
//         // ValidIssuer = "https://localhost:7228",

//       };
//     });
//   }

//   public static void Config_DB_Identity_Config(this IServiceCollection srvc, IConfiguration config)
//   {
//     srvc.AddSingleton<IConfigureOptions<IdentityOptions>, AuthOptionSetup>();

//     srvc.Configure<IdentityOptions>(options =>
//     {
//       // Customize Identity options here
//       options.Password.RequireDigit = true;
//       options.Password.RequiredLength = 5;
//       options.Password.RequireNonAlphanumeric = false;
//     });


//     // Configure Authentication

//     srvc.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//       .AddJwtBearer(options =>
//       {
//         using var serviceProvider = srvc.BuildServiceProvider();
//         var jwtSettings = serviceProvider.GetRequiredService<IOptions<JwtSettings>>().Value;

//         options.RequireHttpsMetadata = false;
//         options.SaveToken = true;
//         options.TokenValidationParameters = new TokenValidationParameters
//         {
//           ValidateIssuerSigningKey = true,
//           IssuerSigningKey = jwtSettings.GetSymmetricSecurityKey(),
//           ValidIssuer = jwtSettings.Issuer,
//           ValidAudience = jwtSettings.Audience,
//           ValidateIssuer = false, // Prod
//           ValidateAudience = false, // Prod
//           ValidateLifetime = false, // Prod
//           ClockSkew = TimeSpan.Zero
//         };
//       });

//   }
// }
