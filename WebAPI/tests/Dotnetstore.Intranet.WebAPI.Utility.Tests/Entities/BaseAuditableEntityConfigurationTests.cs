using System.ComponentModel.DataAnnotations;
using Dotnetstore.Intranet.WebAPI.Utility.Entities;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Dotnetstore.Intranet.WebAPI.Utility.Tests.Entities;

public class BaseAuditableEntityConfigurationTests
{
    private class TestAuditableEntity : BaseAuditableEntity
    {
        [Key]
        public Guid Id { get; set; }
    }

    private class TestAuditableEntityConfiguration : BaseAuditableEntityConfiguration<TestAuditableEntity> { }

    private class TestDbContext(DbContextOptions<TestDbContext> options) : DbContext
    {
        public DbContextOptions<TestDbContext> Options { get; } = options;
        public DbSet<TestAuditableEntity> TestEntities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new TestAuditableEntityConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("TestDatabase");
        }
    }

    [Fact]
    public void Configure_SetsCorrectProperties()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<TestDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

        // Act
        using var context = new TestDbContext(options);
        var entityType = context.Model.FindEntityType(typeof(TestAuditableEntity));
        var properties = entityType!.GetProperties().ToList();

        // Assert
        using (new FluentAssertions.Execution.AssertionScope())
        {
            properties.Should().Contain(p => p.Name == nameof(BaseAuditableEntity.CreatedBy) && p.IsNullable);
            properties.Should().Contain(p => p.Name == nameof(BaseAuditableEntity.CreatedDate) && !p.IsNullable);
            properties.Should().Contain(p => p.Name == nameof(BaseAuditableEntity.LastUpdatedBy) && p.IsNullable);
            properties.Should().Contain(p => p.Name == nameof(BaseAuditableEntity.LastUpdatedDate) && p.IsNullable);
            properties.Should().Contain(p => p.Name == nameof(BaseAuditableEntity.IsDeleted) && !p.IsNullable);
            properties.Should().Contain(p => p.Name == nameof(BaseAuditableEntity.DeletedBy) && p.IsNullable);
            properties.Should().Contain(p => p.Name == nameof(BaseAuditableEntity.DeletedDate) && p.IsNullable);
            properties.Should().Contain(p => p.Name == nameof(BaseAuditableEntity.IsSystem) && !p.IsNullable);
            properties.Should().Contain(p => p.Name == nameof(BaseAuditableEntity.IsGdpr) && !p.IsNullable);
        }
    }
}