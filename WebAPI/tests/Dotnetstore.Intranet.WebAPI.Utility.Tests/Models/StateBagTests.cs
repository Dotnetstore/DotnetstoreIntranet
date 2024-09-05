using Dotnetstore.Intranet.WebAPI.Utility.Models;
using FluentAssertions;
using Xunit;

namespace Dotnetstore.Intranet.WebAPI.Utility.Tests.Models;

public class StateBagTests
{
    [Fact]
    public void StatusProperty_SetAndGet_ReturnsCorrectValue()
    {
        // Arrange
        var stateBag = new StateBag();
        const string expectedStatus = "Running";

        // Act
        stateBag.Status = expectedStatus;
        var actualStatus = stateBag.Status;

        // Assert
        expectedStatus.Should().Be(actualStatus);
    }

    [Fact]
    public void DurationMillisProperty_AfterInitialization_ReturnsNonNegativeValue()
    {
        // Arrange
        var stateBag = new StateBag();

        // Act
        Thread.Sleep(10); // Ensure some time has passed
        var durationMillis = stateBag.DurationMillis;

        // Assert
        durationMillis.Should().BeGreaterOrEqualTo(0);
    }
}