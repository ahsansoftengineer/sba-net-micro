using GLOB.Domain.Base;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace GLOB.API.Staticz;
public static class _Res
{
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

    public static ObjectResult BadRequestModel(this IdentityError error, ModelStateDictionary modelState)
    {
        modelState.AddModelError(error.Code, error.Description);
        return BadRequestModel(modelState);
    }

    public static ObjectResult BadRequestzId(string code, int id, ModelStateDictionary modelState)
    {
        return BadRequestzId(code, id.ToString(), modelState);
    }

    public static ObjectResult BadRequestzId(string code, string id, ModelStateDictionary modelState)
    {
        return BadRequestModel(new IdentityError
        {
            Code = code,
            Description = $"Invalid {code} {id}"
        }, modelState);
    }

    public static ObjectResult CreatedAtAction(ControllerBase controller, string location, IEntityAlpha entity)
    {
        return controller.CreatedAtAction(location, new { Id = entity.Id }, entity);
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
        return new NotFoundObjectResult($"Invalid {key} {id}");
    }

    public static ObjectResult InvalidEnums(string status)
    {
        return new NotFoundObjectResult($"Invalid data {status} not updated the record");
    }

    public static ObjectResult NotAuthorised()
    {
        return new BadRequestObjectResult($"You don't have permission to perform the action");
    }
}
