using GLOB.Domain.Base;
using GLOB.Domain.Hierarchy;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GLOB.Domain.Projectz;
public class VM_Test1 : BaseVM<API_Infra_EntityTest>
{
  [ValidateNever]
  public IEnumerable<SelectListItem> Test2 { get; set; }
}