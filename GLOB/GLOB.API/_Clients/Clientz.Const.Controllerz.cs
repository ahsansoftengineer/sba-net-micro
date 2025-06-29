namespace GLOB.API.Clientz;


public static class Controllerz
{
  public readonly static ControllerzAuth Auth = ControllerzAuth;
  public readonly static ControllerzHierarchy Hierarchy = ControllerzHierarchy;
}

public static class ControllerzX
{
  public const string ProjectzLookupBase = "_projectz-lookup-base";
  public const string ProjectzLookup = "_projectz-lookup";
}
public static class ControllerzAuth : ControllerzX
{
  public const string userz = "userz";
  public const string rolez = "rolez";
  public const string permission = "permission";
  
}
public static class ControllerzHierarchy : ControllerzX
{
  public const string GlobalLookupBase = "_global-lookup-base";
  public const string GlobalLookup = "_global-lookup";

  public const string country = "country";
  public const string state = "state";
  public const string city = "city";
  
}