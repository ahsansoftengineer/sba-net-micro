using System.Text.RegularExpressions;

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