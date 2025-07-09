
namespace SBA.Projectz.Srvc;

public class SrvcInfo
{
  public string date = DateTime.Now.ToString("dd-MMM-yyyy HH:mm:ss");
  public void SendEmail(object data)
  {
    Console.WriteLine($"Sending Email...: Short Running Task {date}");
  }
  public void SendNotification(object data)
  {
    Console.WriteLine($"Sending Notification...: Short Running Task {date}");
  }
  public void SendSMS(object data)
  {
    Console.WriteLine($"Sending SMS...: Short Running Task {date}");
  }
  
}