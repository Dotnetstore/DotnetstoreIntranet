using System.Net;
using Dotnetstore.Intranet.WebAPI.Organization.Users.GetAll;
using Dotnetstore.Intranet.WebAPI.SDK.Dto.Organization.Users.Responses;
using FastEndpoints;
using FastEndpoints.Testing;
using FluentAssertions;
using Xunit;

namespace Dotnetstore.Intranet.WebAPI.Organization.Tests.Integration.Users.GetAll;

public class GetAllUserEndpointTests(DotnetstoreIntranetOrganizationBase dotnetstoreIntranetOrganizationBase)
    : TestBase<DotnetstoreIntranetOrganizationBase>
{
    [Fact]
    public async Task Get_ReturnsOk()
    {
        // Act
        var (rsp, res) = await dotnetstoreIntranetOrganizationBase.Client.GETAsync<GetAllUserEndpoint, IEnumerable<UserResponse>>();

        // Assert
        rsp.StatusCode.Should().Be(HttpStatusCode.OK);
        res.Should().NotBeNull();
    }
}