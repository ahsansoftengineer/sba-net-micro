using GLOB.Domain.Entity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GLOB.Domain.VM;
public class VM_Amenity : BaseVM<Userzz>
{
  [ValidateNever]
  public IEnumerable<SelectListItem> VillaList { get; set; }
}