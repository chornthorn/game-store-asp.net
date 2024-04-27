using Microsoft.AspNetCore.Authorization;

namespace GameStore.Api.Authorization;

public static class PolicyMapper
{
    public static void RequireGamesReadAll(this AuthorizationPolicyBuilder policy)
    {
        policy.RequireClaim("scope", "games:read_all");
    }

    public static void RequireGamesReadOne(this AuthorizationPolicyBuilder policy)
    {
        policy.RequireClaim("scope", "games:read_one");
    }

    public static void RequireGamesCreate(this AuthorizationPolicyBuilder policy)
    {
        policy.RequireClaim("scope", "games:create");
    }

    public static void RequireGamesUpdate(this AuthorizationPolicyBuilder policy)
    {
        policy.RequireClaim("scope", "games:update");
    }

    public static void GamesDelete(this AuthorizationPolicyBuilder policy)
    {
        policy.RequireClaim("scope", "games:delete");
    }
}
