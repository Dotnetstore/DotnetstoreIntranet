namespace Dotnetstore.Intranet.API.Organization.Users;

internal interface IUserRepository
{
    ValueTask<List<User>> GetAllNotSystemAsync(CancellationToken ct);
}