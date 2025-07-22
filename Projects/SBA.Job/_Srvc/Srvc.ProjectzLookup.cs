namespace SBA.Projectz.Srvc;

public class SrvcProjectzLookup
{
  public string date => DateTime.Now.ToString("dd-MMM-yyyy HH:mm:ss");
  public void GenerateMerchandise()
  {
    $"GenerateMerchandise: Long Running Task {date}".Print("[Job]");
  }
  public void BulkCreate()
  {
    $"BulkCreate: Long Running Task {date}".Print("[Job]");
  }

  public void BulkUpdate()
  {
    $"BulkUpdate: Long Running Task {date}".Print("[Job]");
  }
  public void SyncData()
  {
    $"SyncData: Long Running Task {date}".Print("[Job]");
  }
  public void UpdateDatabase()
  {
    $"UpdateDatabase: Long Running Task {date}".Print("[Job]");
  }
  
}