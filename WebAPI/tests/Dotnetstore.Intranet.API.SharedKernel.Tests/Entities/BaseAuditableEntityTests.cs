using Dotnetstore.Intranet.API.SharedKernel.Entities;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Dotnetstore.Intranet.API.SharedKernel.Tests.Entities;

public class BaseAuditableEntityTests
{
    private class TestAuditableEntity : BaseAuditableEntity;

    [Fact]
    public void Properties_SetAndGet_ReturnsCorrectValues()
    {
        // Arrange
        var entity = new TestAuditableEntity();
        var createdBy = Guid.NewGuid();
        var createdDate = DateTimeOffset.UtcNow;
        var lastUpdatedBy = Guid.NewGuid();
        var lastUpdatedDate = DateTimeOffset.UtcNow.AddMinutes(5);
        var deletedBy = Guid.NewGuid();
        var deletedDate = DateTimeOffset.UtcNow.AddMinutes(10);

        // Act
        entity.CreatedBy = createdBy;
        entity.CreatedDate = createdDate;
        entity.LastUpdatedBy = lastUpdatedBy;
        entity.LastUpdatedDate = lastUpdatedDate;
        entity.IsDeleted = true;
        entity.DeletedBy = deletedBy;
        entity.DeletedDate = deletedDate;
        entity.IsSystem = true;
        entity.IsGdpr = true;

        // Assert
        using (new AssertionScope())
        {
            entity.CreatedBy.Should().Be(createdBy);
            entity.CreatedDate.Should().Be(createdDate);
            entity.LastUpdatedBy.Should().Be(lastUpdatedBy);
            entity.LastUpdatedDate.Should().Be(lastUpdatedDate);
            entity.IsDeleted.Should().BeTrue();
            entity.DeletedBy.Should().Be(deletedBy);
            entity.DeletedDate.Should().Be(deletedDate);
            entity.IsSystem.Should().BeTrue();
            entity.IsGdpr.Should().BeTrue();
        }
    }
}