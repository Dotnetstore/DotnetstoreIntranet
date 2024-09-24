using Dotnetstore.Intranet.WebAPI.SDK;
using Dotnetstore.Intranet.WebAPI.SDK.Dto.Organization.Users.Requests;
using Dotnetstore.Intranet.WebAPI.SDK.Dto.Organization.Users.Responses;
using Dotnetstore.Intranet.WebAPI.Utility.Loggers;
using FastEndpoints;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Dotnetstore.Intranet.WebAPI.Organization.Users.Create;


internal sealed class CreateUserEndpoint(IUserService userService) : Endpoint<CreateUserRequest, Results<Ok<UserResponse>, Conflict<ProblemDetails>, BadRequest<ProblemDetails>>>
{
    public override void Configure()
    {
        Post(ApiEndpoints.Organization.Users.Create);
        Description(b => b
            .WithDescription("Create a new user")
            .WithTags("Organization/User"));
        Summary(s =>
        {
            s.ExampleRequest = new CreateUserRequest
            {
                Username = "test@test.com",
                FirstName = "Test",
                LastName = "Testsson",
                MiddleName = "Testare",
                EnglishName = "Testing",
                SocialSecurityNumber = "123456789",
                DateOfBirth = new DateTime(1971, 5, 20),
                IsMale = true,
                LastNameFirst = true,
                Password = "Test123!",
                ConfirmPassword = "Test123!"
            };
        });
        AllowAnonymous();
        PreProcessor<RequestLogger<CreateUserRequest>>();
        PostProcessor<DurationLogger<CreateUserRequest>>();
    }

    public override async Task HandleAsync(CreateUserRequest req, CancellationToken ct)
    {
        var test = userService.GetHashCode();
        await Task.CompletedTask;
        // var result = await userService.CreateAsync(req, ct);
        //
        // if (result.IsSuccess)
        // {
        //     await SendResultAsync(TypedResults.Ok(result.Value));
        // }
        // else
        // {
        //     if (result..FirstError.Type == ErrorType.Conflict)
        //     {
        //         await SendResultAsync(TypedResults.Conflict(new ProblemDetails
        //         {
        //             Detail = result.FirstError.Code,
        //             Status = StatusCodes.Status409Conflict
        //         }));
        //     }
        //     else
        //     {
        //         await SendResultAsync(TypedResults.BadRequest(new ProblemDetails
        //         {
        //             Detail = result.FirstError.Code,
        //             Status = StatusCodes.Status400BadRequest
        //         }));
        //     }
        // }
        //
        // if (result.)
        // {
        //     if (result.FirstError.Type == ErrorType.Conflict)
        //         await SendResultAsync(TypedResults.Conflict(new ProblemDetails
        //         {
        //             Detail = result.FirstError.Code,
        //             Status = StatusCodes.Status409Conflict
        //         }));
        //     else
        //         await SendResultAsync(TypedResults.BadRequest(new ProblemDetails
        //         {
        //             Detail = result.FirstError.Code,
        //             Status = StatusCodes.Status400BadRequest
        //         }));
        // }
        // else
    }
}