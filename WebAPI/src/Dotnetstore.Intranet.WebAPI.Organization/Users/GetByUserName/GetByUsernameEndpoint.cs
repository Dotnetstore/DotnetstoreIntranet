using Dotnetstore.Intranet.WebAPI.SDK;
using Dotnetstore.Intranet.WebAPI.SDK.Dto.Organization.Users.Requests;
using Dotnetstore.Intranet.WebAPI.SDK.Dto.Organization.Users.Responses;
using Dotnetstore.Intranet.WebAPI.Utility.Loggers;
using FastEndpoints;
using Microsoft.AspNetCore.Http;

namespace Dotnetstore.Intranet.WebAPI.Organization.Users.GetByUserName;

internal sealed class GetByUsernameEndpoint(IUserService userService) : Endpoint<GetByUsernameRequest, UserResponse?>
{
    public override void Configure()
    {
        Get(ApiEndpoints.Organization.Users.GetByUsername);
        Description(b => b
            .WithDescription("Get user by username")
            .WithTags("Organization/User"));
        AllowAnonymous();
        PreProcessor<RequestLogger<GetByUsernameRequest>>();
    }

    public override async Task HandleAsync(GetByUsernameRequest req, CancellationToken ct)
    {
        var user = await userService.GetByUsernameAsync(req.Username, ct);

        if (user is null)
        {
            await SendNotFoundAsync(ct);
            return;
        }
        
        await SendAsync(user, statusCode: 200, ct);
    }
}