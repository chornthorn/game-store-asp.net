namespace GameStore.Api.Core.attributes;

[AttributeUsage(AttributeTargets.Class)]
public class InjectableAttribute : Attribute
{
    public bool Scoped { get; }

    public InjectableAttribute(bool Scoped = true)
    {
        this.Scoped = Scoped;
    }
}
