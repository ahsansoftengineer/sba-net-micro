using GLOB.API.Config.Configz;
using GLOB.Domain.Base;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace GLOB.API.Staticz;

public static class _Res
{
  public static ObjectResult Ok(string msg)
  {
    return new ObjectResult(new { Message = msg, Status = 200});
  }
  public static ObjectResult CatchException(this Exception ex, string methodName)
  {
    Console.WriteLine(ex.Message, $"Something went wrong in the {methodName}");
    return new ObjectResult("Internal Server Error, Please try again later") { StatusCode = 500 };
  }

  public static ObjectResult BadRequestModel(this ModelStateDictionary modelState)
  {
    foreach (var ms in modelState)
    {
      Console.WriteLine($"{ms.Key} :\t {ms.Value}");
    }

    if (!modelState.Any(x => x.Key == "Message"))
      modelState.AddModelError("Message", "Bad Request 400");

    return new BadRequestObjectResult(modelState);
  }

  public static ObjectResult BadRequestModel(this IdentityError error, ModelStateDictionary modelState = null)
  {
    modelState ??= new ModelStateDictionary();
    modelState.AddModelError(error.Code, error.Description);
    return BadRequestModel(modelState);
  }
  public static ObjectResult BadRequestModel(string Title, string Message)
  {
    var modelState = new ModelStateDictionary();
    modelState.AddModelError(Title, Message);
    return BadRequestModel(modelState);
  }

  public static ObjectResult BadRequestzId(string code, int id)
  {
    return BadRequestzId(code, id.ToString());
  }

  public static ObjectResult BadRequestzId(string code, string id)
  {
    return BadRequestModel(new IdentityError
    {
      Code = code,
      Description = $"Invalid {code} {id}"
    });
  }

  public static ObjectResult CreatedAtAction(ControllerBase controller, string location, IEntityAlpha entity)
  {
    return controller.CreatedAtAction(location, new { entity.Id }, entity);
  }

  public static ObjectResult NotFoundId(string id)
  {
    return NotFoundId("Id", id);
  }

  public static ObjectResult NotFoundId(int id)
  {
    return NotFoundId("Id", id.ToString());
  }

  public static ObjectResult NotFoundId(string key, int id)
  {
    return NotFoundId(key, id.ToString());
  }

  public static ObjectResult NotFoundId(string key, string id)
  {
    var modelState = new ModelStateDictionary();
    modelState.AddModelError(key, $"Invalid {key} {id} does not exsist");

    var errors = ExtConfig.ToExtValidationError(modelState);
    return new NotFoundObjectResult(new
    {
        Errors = errors,
        Message = "Bad Request, Validation Failed"
    });
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
