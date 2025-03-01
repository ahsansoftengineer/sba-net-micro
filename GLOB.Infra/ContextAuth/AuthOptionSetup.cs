using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace GLOB.Infra.Context.Auth;
public class AuthOptionSetup : IConfigureOptions<IdentityOptions>
{
    private readonly IdentitySettings _identitySettings;

    public AuthOptionSetup(IOptions<IdentitySettings> identitySettings)
    {
        _identitySettings = identitySettings.Value;
    }

    public void Configure(IdentityOptions options)
    {
        // User settings
        options.User.RequireUniqueEmail = _identitySettings.RequireUniqueEmail;

        // Password settings
        options.Password.RequireDigit = _identitySettings.Password.RequireDigit;
        options.Password.RequiredLength = _identitySettings.Password.RequiredLength;
        options.Password.RequireNonAlphanumeric = _identitySettings.Password.RequireNonAlphanumeric;
        options.Password.RequireUppercase = _identitySettings.Password.RequireUppercase;
        options.Password.RequireLowercase = _identitySettings.Password.RequireLowercase;

        // Lockout settings
        options.Lockout.MaxFailedAccessAttempts = _identitySettings.Lockout.MaxFailAttempts;
        options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(_identitySettings.Lockout.LockoutMinutes);
    }
}
