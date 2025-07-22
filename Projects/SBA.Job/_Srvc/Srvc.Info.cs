
namespace SBA.Projectz.Srvc;

public class SrvcInfo
{
  public string date = DateTime.Now.ToString("dd-MMM-yyyy HH:mm:ss");
  public void SendEmail(object data)
  {
    $"Sending Email...: Short Running Task {date}".Print("[Task]");
  }
  public void SendNotification(object data)
  {
    $"Sending Notification...: Short Running Task {date}".Print("[Task]");
  }
  public void SendSMS(object data)
  {
    $"Sending SMS...: Short Running Task {date}".Print("[Task]");
  }
  
}