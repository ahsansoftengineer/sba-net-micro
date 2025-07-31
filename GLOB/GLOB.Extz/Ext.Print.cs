namespace GLOB.Extz;

public static partial class Ext
{
    public static void Print(this object obj, string? heading = null)
    {
        try
        {
            string result = JsonConvert.SerializeObject(obj, Formatting.Indented);
            result = result.Replace("\"", "");
            Console.WriteLine("--> [{0}] \n{1}", heading ?? "Object", result);
        }
        catch (Exception ex)
        {
            Console.WriteLine("--> [Print Exception] : " + ex.Message);
        }
    }
    public static void Print(this Exception ex, string? heading = null)
    {
        ex.Message.Print($"[{heading ?? "Exception"}]");
    }
    public static void Print(this string value, string? heading = null)
    {
        Console.WriteLine("--> [{0}]\t-\t{1}\n", (heading ?? "[Message]"), value);
    }
    public static void Print()
    {
        Console.WriteLine("------------------------****-*-****------------------------");
    }

}