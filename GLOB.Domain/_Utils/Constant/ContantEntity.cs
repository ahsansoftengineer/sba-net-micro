using GLOB.Domain.Enums;

namespace GLOB.Domain.Contants;
public static class Constantz
{
  // TODO: We need to have a way of setting Default Date for Migration on 
  public static Status? Status { get; } = Enums.Status.None;
  public static  DateTimeOffset Date { get; } = DateTimeOffset.Parse("2025-02-10T00:00:00");
  public static string Guidz() => Guid.NewGuid().ToString();
}