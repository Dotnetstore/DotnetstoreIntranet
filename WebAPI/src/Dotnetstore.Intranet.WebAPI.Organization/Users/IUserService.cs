using Dotnetstore.Intranet.WebAPI.SDK.Dto.Organization.Users.Responses;

namespace Dotnetstore.Intranet.WebAPI.Organization.Users;

internal interface IUserService
{
    ValueTask<IEnumerable<UserResponse>> GetAllNotSystemAsync(CancellationToken ct);
}