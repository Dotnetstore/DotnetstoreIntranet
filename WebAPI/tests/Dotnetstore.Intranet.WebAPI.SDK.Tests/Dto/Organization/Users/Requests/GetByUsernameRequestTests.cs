using Dotnetstore.Intranet.WebAPI.SDK.Dto.Organization.Users.Requests;
using FluentAssertions;
using Xunit;

namespace Dotnetstore.Intranet.WebAPI.SDK.Tests.Dto.Organization.Users.Requests;

public class GetByUsernameRequestTests
{
    [Fact]
    public void Constructor_SetsPropertiesCorrectly()
    {
        // Arrange
        const string username = "johndoe";

        // Act
        var request = new GetByUsernameRequest(username);

        // Assert
        request.Username.Should().Be(username);
    }
}