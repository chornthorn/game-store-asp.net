using GameStore.Api.Core.types;

namespace GameStore.Api.Core.attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true)]
public class PreAuthorizeAttribute : Attribute
{
    public required string Resource { get; set; }
    public ActionScope Action { get; set; } = ActionScope.ReadOne;

    public PreAuthorizeAttribute(string resource, ActionScope action)
    {
        Resource = resource;
        Action = action;
    }
}
