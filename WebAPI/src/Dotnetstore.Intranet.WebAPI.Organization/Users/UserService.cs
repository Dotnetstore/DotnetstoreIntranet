using Ardalis.Result;
using Dotnetstore.Intranet.WebAPI.Organization.UserInUserRoles;
using Dotnetstore.Intranet.WebAPI.Organization.UserRoles;
using Dotnetstore.Intranet.WebAPI.Organization.Users.Create;
using Dotnetstore.Intranet.WebAPI.SDK.Dto.Organization.Users.Requests;
using Dotnetstore.Intranet.WebAPI.SDK.Dto.Organization.Users.Responses;
using Dotnetstore.Intranet.WebAPI.Utility.Services;

namespace Dotnetstore.Intranet.WebAPI.Organization.Users;

internal sealed class UserService(
    IUserRepository userRepository,
    IUserInUserRoleService userInUserRoleService) : IUserService
{
    async ValueTask<IEnumerable<UserResponse>> IUserService.GetAllNotSystemAsync(CancellationToken ct)
    {
        var result = await userRepository
            .GetAllNotSystemAsync(ct);
        
        return result.Select(x => x.ToUserResponse()).ToList();
    }

    async ValueTask<Result<UserResponse>> IUserService.CreateAsync(CreateUserRequest request, CancellationToken cancellationToken)
    {
        if (await UserExistsAsync(request.Username, cancellationToken))
            return Result.Conflict("User already exists");
        
        var user = CreateUser(request);
        
        await AddUserRolesAsync(user, cancellationToken);
        userRepository.Create(user);
        await userRepository.SaveChangesAsync(cancellationToken);

        return await GetUserById(user.UserId, cancellationToken);
    }

    async ValueTask<UserResponse?> IUserService.GetByUsernameAsync(string username, CancellationToken ct)
    {
        var result = await userRepository.GetByUsernameAsync(username, ct);
        return result?.ToUserResponse();
    }

    private async ValueTask<bool> UserExistsAsync(string username, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByUsernameAsync(username, cancellationToken);
        return user is not null;
    }

    private static User CreateUser(CreateUserRequest request)
    {
        return CreateUserBuilder.CreateNewUser()
            .CreateUserId()
            .SetPersonalData(request)
            .SetCredentials(request)
            .SetMetaData()
            .Build();
    }
    
    private async ValueTask AddUserRolesAsync(User user, CancellationToken cancellationToken)
    {
        var allUsers = await userRepository.GetAllNotSystemAsync(cancellationToken);

        if (allUsers.Count == 0)
            await AddUserRoleAsync(user, Constants.UserRoleAdministratorId, cancellationToken);
        
        await AddUserRoleAsync(user, Constants.UserRoleUserId, cancellationToken);
    }
    
    private async ValueTask AddUserRoleAsync(User user, Guid userRoleId, CancellationToken cancellationToken)
    {
        var userRole = UserInUserRoleBuilder.Create()
            .CreateId()
            .CreateObjectData(user.UserId, new UserRoleId(userRoleId))
            .CreateMetadata()
            .Build();
        
        await userInUserRoleService.CreateAsync(userRole, cancellationToken);
    }
    
    private async ValueTask<Result<UserResponse>> GetUserById(
        UserId userId, 
        CancellationToken cancellationToken)
    {
        var createdUser = await userRepository.GetByIdAsync(userId, cancellationToken);
        
        if (createdUser is null)
            return Result.NotFound("Can't find any user with this id.");
        
        return createdUser.ToUserResponse();
    }
}