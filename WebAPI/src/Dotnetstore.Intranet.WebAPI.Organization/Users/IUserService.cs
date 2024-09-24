using Ardalis.Result;
using Dotnetstore.Intranet.WebAPI.SDK.Dto.Organization.Users.Requests;
using Dotnetstore.Intranet.WebAPI.SDK.Dto.Organization.Users.Responses;

namespace Dotnetstore.Intranet.WebAPI.Organization.Users;

internal interface IUserService
{
    ValueTask<IEnumerable<UserResponse>> GetAllNotSystemAsync(CancellationToken ct);
    
    ValueTask<Result<UserResponse>> CreateAsync(CreateUserRequest request, CancellationToken cancellationToken);
    
    ValueTask<UserResponse?> GetByUsernameAsync(string username, CancellationToken ct);
}