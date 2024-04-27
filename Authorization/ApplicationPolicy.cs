namespace GameStore.Api.Authorization;

public static class ApplicationPolicy
{
    public static IServiceCollection ApplyApplicationPolicy(this IServiceCollection services)
    {
        services.AddAuthorization(options =>
        {
            options.AddPolicy(Policies.GamesReadAll, policy =>
            {
                policy.RequireClaim("scope", "games:read_all");
            });

            options.AddPolicy(Policies.GamesReadOne, policy =>
            {
                policy.RequireClaim("scope", "games:read_one");
            });
        });

        return services;
    }
}
