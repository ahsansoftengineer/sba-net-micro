using System.ComponentModel.DataAnnotations.Schema;
using GLOB.Domain.Base;

namespace GLOB.Domain.Hierarchy;
public class Profession : BaseEntity
{
  // [NotMapped]
  // public ICollection<Mapping_UserCreatorProfession>? UserCreatorProfessions { get; set; } = new List<Mapping_UserCreatorProfession>();

}
