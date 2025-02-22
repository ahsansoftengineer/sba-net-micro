using System.ComponentModel.DataAnnotations.Schema;
using GLOB.Domain.Base;

namespace GLOB.Domain.Entity;
public class Bank : BaseEntity
{
  // [NotMapped]
  // public ICollection<BankAccount>? BankAccount { get; set; }
}
