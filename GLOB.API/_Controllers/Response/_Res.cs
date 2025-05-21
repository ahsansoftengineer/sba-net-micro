using GLOB.Domain.Base;
using Microsoft.AspNetCore.Mvc;

namespace GLOB.API.Staticz;

public static partial class _Res
{
  public static OkObjectResult Ok(this object obj)
  {
    return new OkObjectResult(obj);
  }
  public static ObjectResult Ok(this string msg)
  {
    return Ok(new { Message = msg, Status = 200});
  }
  public static ObjectResult CatchException(this Exception ex, string methodName)
  {
    Console.WriteLine($"Something went wrong in the {methodName}", ex.Message);
    return new ObjectResult("Internal Server Error, Please try again later") { StatusCode = 500 };
  }

  public static ObjectResult CreatedAtAction(ControllerBase controller, string location, IEntityAlpha entity)
  {
    return controller.CreatedAtAction(location, new { entity.Id }, entity);
  }

  public static ObjectResult InvalidEnums(string status)
  {
    return new NotFoundObjectResult($"Invalid enum {status} not updated the record");
  }

  public static ObjectResult NotAuthorised()
  {
    return new BadRequestObjectResult($"You don't have permission to perform the action");
  }
}
