using System.Reflection;
using GameStore.Api.Core.attributes;

namespace GameStore.Api.Core;

public static class ServiceCollectionExtensions
{
    public static void AutoDependencyInjection(this IServiceCollection services)
    {
        // Get all the types in the current assembly
        var types = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(s => s.GetTypes())
            .Where(p => Attribute.IsDefined(p, typeof(InjectableAttribute)));

        // Check if any types were found
        if (!types.Any())
        {
            throw new Exception("No types found with the [Injectable] attribute.");
        }

        // Find root dependencies (types that are not dependencies of any other types)
        var rootDependencies = types
            .Where(t => !types.Any(otherType => otherType.GetConstructors()
                .Any(c => c.GetParameters().Any(p => p.ParameterType == t))));

        // Register root dependencies
        foreach (var type in rootDependencies)
        {
            // check if the type has a Scoped true [Injectable(Scoped: true)]
            var attribute = type.GetCustomAttribute<InjectableAttribute>();
            if (attribute != null && attribute.Scoped)
            {
                services.AddScoped(type);
            }
            else
            {
                services.AddSingleton(type);
            }
        }

        // Register other dependencies
        var otherDependencies = types.Except(rootDependencies);
        foreach (var type in otherDependencies)
        {
            // check if the type has a Scoped true [Injectable(Scoped: true)]
            var attribute = type.GetCustomAttribute<InjectableAttribute>();
            if (attribute != null && attribute.Scoped)
            {
                services.AddScoped(type);
            }
            else
            {
                services.AddSingleton(type);
            }
        }

        // console log dependencies tree and its dependencies and scoped
        Console.WriteLine("----------------------------------------------------------");
        Console.WriteLine("Dependencies tree:");
        foreach (var type in types)
        {
            var attribute = type.GetCustomAttribute<InjectableAttribute>();
            var constructor = type.GetConstructors().FirstOrDefault();
            var parameters = constructor?.GetParameters();
            var dependencies = parameters?.Select(p => p.ParameterType.Name).ToList();

            if (dependencies != null)
            {
                // if service not have dependencies
                if (dependencies.Count == 0)
                {
                    Console.WriteLine($"{type.Name} -> None");
                }
                else
                {
                    Console.WriteLine($"{type.Name} -> {string.Join(" -> ", dependencies)}");
                }
            }
            else
            {
                Console.WriteLine($"{type.Name}");
            }
        }

        Console.WriteLine("----------------------------------------------------------");
    }
}
