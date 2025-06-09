namespace GLOB.API.Config.Configz;

public class SocialAccounts
{
  public static string SectionName = "SocialAccounts";
  public SocialAccount Google { get; set; }
  public SocialAccount Microsoft { get; set; }
  public SocialAccount Facebook { get; set; }
  public SocialAccount Github { get; set; }
  public SocialAccount LinkedIn { get; set; }
  public SocialAccount Twitter { get; set; }
  public SocialAccount Apple { get; set; }

}
public class SocialAccount
{
  public string Scheme { get; set; } // Google, Microsoft, Facebook, Apple
  public string ClientId { get; set; }
  public string ClientSecret { get; set; }
  public string AuthorizationEndpoint { get; set; }
  public string TokenEndpoint { get; set; }
  public string UserInformationEndpoint { get; set; }
  public string CallbackPath { get; set; }
  public List<string> Scopes { get; set; } = new();
  public Dictionary<string, string> ClaimMap { get; set; } = new();
}