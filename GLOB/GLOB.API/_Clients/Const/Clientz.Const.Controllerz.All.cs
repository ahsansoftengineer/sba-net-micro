namespace GLOB.API.Clientz;

public class ControllerzX
{
  public static readonly string ProjectzLookupBase = "_projectz-lookup-base";
  public static readonly string ProjectzLookup = "_projectz-lookup";
}
public class ControllerzAuth : ControllerzX
{
  public static readonly string userz = "userz";
  public static readonly string rolez = "rolez";
  public static readonly string permission = "permission";
  
}
public class ControllerzHierarchy : ControllerzX
{
  public static readonly string GlobalLookupBase = "_global-lookup-base";
  public static readonly string GlobalLookup = "_global-lookup";

  public static readonly string country = "country";
  public static readonly string state = "state";
  public static readonly string city = "city";
  
}