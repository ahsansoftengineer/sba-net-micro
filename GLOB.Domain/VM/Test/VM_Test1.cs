using GLOB.Domain.Entity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GLOB.Domain.VM;
public class VM_Test1 : BaseVM<Test1>
{
  [ValidateNever]
  public IEnumerable<SelectListItem> Test2 { get; set; }
}