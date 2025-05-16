using Microsoft.AspNetCore.Authentication;

namespace SBA.Projectz.DI;

public static partial class DI_Projectz
{
  public static AuthenticationBuilder Config_Social_Auth(this AuthenticationBuilder srvc, IConfiguration config)
  {

    var accounts = new SocialAccounts();
    config.GetSection("SocialAccounts").Bind(accounts);
    return srvc
    .AddGoogle(opt =>
    {
      opt.ClientId = accounts.Google.Id;
      opt.ClientSecret = accounts.Google.Secret;
      opt.ReturnUrlParameter = accounts.Google.ReturnUrl;
      opt.SaveTokens = true;
      opt.Scope.Add("profile");
      opt.Scope.Add("email");
    })
    .AddFacebook(opt =>
    {
      opt.AppId = accounts.Facebook.Id;
      opt.AppSecret = accounts.Facebook.Secret;
      opt.ReturnUrlParameter = accounts.Facebook.ReturnUrl;
      opt.SaveTokens = true;
      opt.Fields.Add("email");
    })
    .AddMicrosoftAccount(options =>
    {
      options.ClientId = accounts.Microsoft.Id;
      options.ClientSecret = accounts.Microsoft.Secret;
      options.CallbackPath = accounts.Microsoft.ReturnUrl;
      options.SaveTokens = true;
      options.Scope.Add("email");
    })
    .AddApple(options =>
    {
      options.ClientId = "com.your.bundle.id";
      options.KeyId = "your-key-id";
      options.TeamId = "your-team-id";
      options.PrivateKey = null;
      options.SaveTokens = true;
    });
  }
}
public class SocialAccounts
{
  public static string SectionName = "SocialAccounts";
  public SocialAccount Microsoft { get; set; }
  public SocialAccount Google { get; set; }
  public SocialAccount Facebook { get; set; }
  public SocialAccount Apple { get; set; }

}
public class SocialAccount
{
  public string Id { get; set; }
  public string Secret { get; set; }
  public string ReturnUrl { get; set; }
  public string AppleAuthority { get; set; } = "https://appleid.apple.com";
  public string CallbackPath { get; set; } = "route-of-yourapp";
}