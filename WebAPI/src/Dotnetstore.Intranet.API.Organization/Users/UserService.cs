using Dotnetstore.Intranet.API.SDK.Organization.Users.Responses;

namespace Dotnetstore.Intranet.API.Organization.Users;

internal sealed class UserService(
    IUserRepository userRepository) : IUserService
{
    async ValueTask<IEnumerable<UserResponse>> IUserService.GetAllNotSystemAsync(CancellationToken ct)
    {
        var result = await userRepository
            .GetAllNotSystemAsync(ct);
        
        return result.Select(x => x.ToUserResponse()).ToList();
    }
}