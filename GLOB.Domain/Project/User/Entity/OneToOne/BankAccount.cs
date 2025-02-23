using GLOB.Domain.Base;

namespace GLOB.Domain.Hierarchy;
public class BankAccount : BaseEntity
{
  // AccountTitle = Title
  public int? UserCreatorID { get; set; } = null;
  public UserCreator? UserCreator { get; set; } = null;
  public int? BankID { get; set; }
  public Bank? Bank { get; set; }
  public string? Cnic { get; set; }
  public string? AccountNumber { get; set; }
  public string? BranchCode { get; set; }
  public string? Iban { get; set; }
  public string? AccountType { get; set; }
  public string? BankCode { get; set; }
}
