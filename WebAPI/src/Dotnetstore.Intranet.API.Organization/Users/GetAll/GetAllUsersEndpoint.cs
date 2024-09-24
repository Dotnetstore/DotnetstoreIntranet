using Dotnetstore.Intranet.API.SDK;
using Dotnetstore.Intranet.API.SDK.Organization.Users.Responses;
using FastEndpoints;
using Microsoft.AspNetCore.Http;

namespace Dotnetstore.Intranet.API.Organization.Users.GetAll;

internal sealed class GetAllUsersEndpoint : EndpointWithoutRequest<IEnumerable<UserResponse>>
{
    public override void Configure()
    {
        Get(ApiEndpoints.Organization.Users.GetAll);
        Description(b => b
            .WithDescription("Get all users")
            .WithTags("Organization/User"));
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var users = new List<UserResponse>();
        
        await SendAsync(users, statusCode: 200, ct);
    }
}