namespace SBA.Projectz.DI;
public static partial class DI_Projectz
{
  public static void Config_Social_Auth(this IServiceCollection srvc, IConfiguration config)
  {
    // srvc.AddGoogle
  }
}
public class SocialAccounts
{
  public static string SectionName = "SocialAccounts";
  public SocialAccount Google { get; set; }
  public SocialAccount Facebook { get; set; }
  public SocialAccount Apple { get; set; }

}
public class SocialAccount
{
  public string ClientId { get; set; }
  public string ClientSecret { get; set; }
}