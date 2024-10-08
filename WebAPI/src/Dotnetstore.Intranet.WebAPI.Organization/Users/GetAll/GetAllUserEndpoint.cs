﻿using Dotnetstore.Intranet.WebAPI.SDK;
using Dotnetstore.Intranet.WebAPI.SDK.Dto.Organization.Users.Responses;
using Dotnetstore.Intranet.WebAPI.Utility.Loggers;
using FastEndpoints;
using Microsoft.AspNetCore.Http;

namespace Dotnetstore.Intranet.WebAPI.Organization.Users.GetAll;

internal sealed class GetAllUserEndpoint(IUserService userService) : EndpointWithoutRequest<IEnumerable<UserResponse>>
{
    public override void Configure()
    {
        Get(ApiEndpoints.Organization.Users.GetAll);
        Description(b => b
            .WithDescription("Get all users")
            .WithTags("Organization/User"));
        AllowAnonymous();
        PreProcessor<RequestLogger<EmptyRequest>>();
        PostProcessor<DurationLogger<EmptyRequest>>();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var result = await userService.GetAllNotSystemAsync(ct);

        await SendAsync(result, statusCode: 200, ct);
    }
}