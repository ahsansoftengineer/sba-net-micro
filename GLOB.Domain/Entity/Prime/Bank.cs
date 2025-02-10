using GLOB.Domain.Base;

namespace GLOB.Domain.Entity;
public class Bank : BaseEntity
{
  public ICollection<BankAccount>? BankAccount { get; set; }
}
