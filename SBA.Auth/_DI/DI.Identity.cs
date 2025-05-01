namespace SBA.Projectz.DI;
public static partial class Projectz_DI
{
 
  public static void Config_DB_Identity_Config(this IServiceCollection srvc, IConfiguration config)
  {
    // srvc.AddSingleton<IConfigureOptions<IdentityOptions>, AuthOptionSetup>();

    // srvc.Configure<IdentityOptions>(options =>
    // {
    //     // Customize Identity options here
    //     options.Password.RequireDigit = true;
    //     options.Password.RequiredLength = 5;
    //     options.Password.RequireNonAlphanumeric = false;
    // });


    // Configure Authentication

    // srvc.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    //   .AddJwtBearer(options =>
    //   {
    //     using var serviceProvider = srvc.BuildServiceProvider();
    //     var jwtSettings = serviceProvider.GetRequiredService<IOptions<JwtSettings>>().Value;

    //     options.RequireHttpsMetadata = false;
    //     options.SaveToken = true;
    //     options.TokenValidationParameters = new TokenValidationParameters
    //     {
    //       ValidateIssuerSigningKey = true,
    //       IssuerSigningKey = jwtSettings.GetSymmetricSecurityKey(),
    //       ValidIssuer = jwtSettings.Issuer,
    //       ValidAudience = jwtSettings.Audience,
    //       ValidateIssuer = false, // Prod
    //       ValidateAudience = false, // Prod
    //       ValidateLifetime = false, // Prod
    //       ClockSkew = TimeSpan.Zero
    //     };
    //   });

  }
}
