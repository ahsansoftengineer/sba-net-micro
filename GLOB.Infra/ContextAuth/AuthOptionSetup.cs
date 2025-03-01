using GLOB.Domain.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace GLOB.Infra.Auth;
public class IdentityOptionsSetup : IConfigureOptions<IdentityOptions>
{
    private readonly IdentitySettings _identitySettings;

    public IdentityOptionsSetup(IOptions<IdentitySettings> identitySettings)
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
        options.Lockout.MaxFailedAccessAttempts = _identitySettings.Lockout.MaxFailedAccessAttempts;
        options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(
            _identitySettings.Lockout.DefaultLockoutTimeSpanInMinutes);
    }
}
