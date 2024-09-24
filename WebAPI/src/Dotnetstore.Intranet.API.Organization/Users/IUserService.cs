using Dotnetstore.Intranet.API.SDK.Organization.Users.Responses;

namespace Dotnetstore.Intranet.API.Organization.Users;

internal interface IUserService
{
    ValueTask<IEnumerable<UserResponse>> GetAllNotSystemAsync(CancellationToken ct);
}