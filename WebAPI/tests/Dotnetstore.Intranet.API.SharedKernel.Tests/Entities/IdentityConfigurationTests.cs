using Dotnetstore.Intranet.API.SharedKernel.Entities;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Dotnetstore.Intranet.API.SharedKernel.Tests.Entities;

public class IdentityConfigurationTests
{
    private class TestIdentity : Identity
    {
        public Guid Id { get; set; }
    }

    private class TestIdentityConfiguration : IdentityConfiguration<TestIdentity> { }

    private class TestDbContext : DbContext
    {
        public DbSet<TestIdentity> TestIdentities { get; set; }

        public TestDbContext(DbContextOptions<TestDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new TestIdentityConfiguration());
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
        var entityType = context.Model.FindEntityType(typeof(TestIdentity));
        var properties = entityType!.GetProperties().ToList();

        // Assert
        using (new FluentAssertions.Execution.AssertionScope())
        {
            properties.Should().Contain(p => p.Name == nameof(Identity.Username) && p.GetMaxLength() == Constants.DefaultUsernameLength && (bool)(!p.IsUnicode())! && !p.IsNullable);
            properties.Should().Contain(p => p.Name == nameof(Identity.Password) && p.GetMaxLength() == Constants.DefaultPasswordLength && (bool)(!p.IsUnicode())! && !p.IsNullable);
            properties.Should().Contain(p => p.Name == nameof(Identity.Salt1) && p.GetMaxLength() == Constants.DefaultSaltLength && (bool)(!p.IsUnicode())! && !p.IsNullable);
            properties.Should().Contain(p => p.Name == nameof(Identity.Salt2) && p.GetMaxLength() == Constants.DefaultSaltLength && (bool)(!p.IsUnicode())! && !p.IsNullable);
            properties.Should().Contain(p => p.Name == nameof(Identity.Salt3) && p.GetMaxLength() == Constants.DefaultSaltLength && (bool)(!p.IsUnicode())! && !p.IsNullable);
            properties.Should().Contain(p => p.Name == nameof(Identity.Salt4) && p.GetMaxLength() == Constants.DefaultSaltLength && (bool)(!p.IsUnicode())! && !p.IsNullable);
            properties.Should().Contain(p => p.Name == nameof(Identity.IsBlocked) && !p.IsNullable);
            properties.Should().Contain(p => p.Name == nameof(Identity.BlockedDate) && p.IsNullable);
        }
    }
}