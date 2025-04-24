using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace GLOB.API.OptionSetup;
public class KebabCaseRouteTransformer : IOutboundParameterTransformer
{
    public string TransformOutbound(object value)
    {
        if (value == null) return null;

        // Convert PascalCase to kebab-case
        return Regex.Replace(value.ToString(), "([a-z])([A-Z])", "$1-$2").ToLower();
    }
}

public class GlobalRouteConvention : IApplicationModelConvention
{
    public void Apply(ApplicationModel application)
    {
        foreach (var controller in application.Controllers)
        {
            var controllerName = ToKebabCase(controller.ControllerName);

            foreach (var action in controller.Actions)
            {
                // Skip if route already exists
                if (action.Selectors.Any(s => s.AttributeRouteModel != null))
                    continue;

                var actionName = ToKebabCase(action.ActionName);
                var template = $"{controllerName}/{actionName}";

                action.Selectors[0].AttributeRouteModel = new AttributeRouteModel
                {
                    Template = template
                };
            }
        }
    }

    private string ToKebabCase(string input)
    {
        return Regex.Replace(input.ToString(), "([a-z])([A-Z])", "$1-$2").ToLower();;
    }
}
