
namespace SBA.Projectz.Srvc;

public class SrvcProjectzLookup
{
  public string date = DateTime.Now.ToString("dd-MMM-yyyy HH:mm:ss");
  public void GenerateMerchandise()
  {
    Console.WriteLine($"GenerateMerchandise: Long Running Task {date}");
  }
  public void BulkCreate()
  {
    Console.WriteLine($"BulkCreate: Long Running Task {date}");
  }

  public void BulkUpdate()
  {
    Console.WriteLine($"BulkUpdate: Long Running Task {date}");
  }
  public void SyncData()
  {
    Console.WriteLine($"SyncData: Long Running Task {date}");
  }
  public void UpdateDatabase()
  {
    Console.WriteLine($"UpdateDatabase: Long Running Task {date}");
  }
  
}