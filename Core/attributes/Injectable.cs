namespace GameStore.Api.Core.attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Interface, Inherited = true)]
public class InjectableAttribute : Attribute
{
    public bool Scoped { get; }

    public InjectableAttribute(bool Scoped = true)
    {
        this.Scoped = Scoped;
    }
}
