public class ACTION
{
    public static readonly string ALL =  "ALL";
    public static readonly string CREATE =  "CREATE";
    public static readonly string READ =  "READ";
    public static readonly string UPDATE =  "UPDATE";
    public static readonly string DELETE =  "DELETE";
    public static readonly string STATUS =  "STATUS";
    public static readonly string REPORT =  "REPORT";
    public static readonly string EXPORT =  "EXPORT";
}

public class ROLE
{
    public static readonly string ADMIN =  "ADMIN";
    public static readonly string USER =  "USER";
    public static readonly string MANAGER =  "MANAGER";
    public static readonly string PERMISSION =  "PERMISSION";
    public static readonly string USER_CREATOR =  "USER_CREATOR";
    public static readonly string USER_STANDARD =  "USER_STANDARD";
    public static readonly string USER_BUSINESS =  "USER_BUSINESS";
    public static readonly string USER_AGENT =  "USER_AGENT";
    public static readonly string USER_MARKETING =  "USER_MARKETING";
    // ROLES TABLE
    public static List<string> ROLES = [
        ADMIN, 
        USER, 
        MANAGER, 
        USER_CREATOR,
        USER_STANDARD,
        USER_BUSINESS,
        USER_AGENT,
        USER_MARKETING
    ];
}
// ROUTE TABLE
public class ROUTES
{
    public static readonly string USER_ADMIN =  "";
    public static readonly string USER_AGENT =  "";
    public static readonly string USER_BUSINESS =  "";
    public static readonly string USER_CREATEOR =  "";
    public static readonly string USER_STANDARD =  "";
    public static readonly string ORDER_STANDARD =  "";
    public static readonly string ORDER_BUSINESS =  "";
    public static readonly string ORDER_BUSINESS_MULTI =  "";
    public static readonly string HUB_SPOT =  "";
    public static readonly string PAYMNET_STANDARD =  "";
    public static readonly string PAYMNET_BUSINESS =  "";
    public static readonly string EMAIL =  "";
    public static readonly string APROVAL =  "";
    public static readonly string INDUSTRY =  "";
    public static readonly string MGMT_ROLE =  "";
    public static readonly string MGMT_PERMISSION =  "";
    public static readonly string LOGS =  "";
    public static readonly string ALTERATION =  "";
    public static readonly string BRANDS =  "";
    public static readonly string TESTAMONIAL =  "";
    public static readonly string NOTIFICATION =  "";
}