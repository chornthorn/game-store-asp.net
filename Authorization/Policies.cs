
namespace GameStore.Api.Authorization;

public static class Policies
{
    public const string GamesReadOne = "games:read_one";
    public const string GamesReadAll = "games:read_all";
    public const string GamesCreate = "games:create";
    public const string GamesUpdate = "games:update";
    public const string GamesDelete = "games:delete";
}
