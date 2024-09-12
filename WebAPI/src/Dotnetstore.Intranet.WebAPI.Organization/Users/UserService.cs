using Dotnetstore.Intranet.WebAPI.SDK.Dto.Organization.Users.Responses;

namespace Dotnetstore.Intranet.WebAPI.Organization.Users;

internal sealed class UserService(IUserRepository userRepository) : IUserService
{
    async ValueTask<IEnumerable<UserResponse>> IUserService.GetAllNotSystemAsync(CancellationToken ct)
    {
        var result = await userRepository
            .GetAllNotSystemAsync(ct);
        
        return result.Select(x => x.ToUserResponse()).ToList();
    }
}