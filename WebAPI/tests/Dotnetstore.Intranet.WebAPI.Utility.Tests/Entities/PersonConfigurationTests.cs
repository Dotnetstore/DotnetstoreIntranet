using System.ComponentModel.DataAnnotations;
using Dotnetstore.Intranet.WebAPI.Utility.Entities;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Dotnetstore.Intranet.WebAPI.Utility.Tests.Entities;

public class PersonConfigurationTests
{
    private class TestPerson : Person
    {
        [Key]
        public Guid Id { get; set; }
    }

    private class TestPersonConfiguration : PersonConfiguration<TestPerson> { }

    private class TestDbContext(DbContextOptions<TestDbContext> options) : DbContext
    {
        public DbContextOptions<TestDbContext> Options { get; } = options;
        public DbSet<TestPerson> TestPersons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new TestPersonConfiguration());
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
        var entityType = context.Model.FindEntityType(typeof(TestPerson));
        var properties = entityType!.GetProperties().ToList();

        // Assert
        using (new FluentAssertions.Execution.AssertionScope())
        {
            properties.Should().Contain(p => p.Name == nameof(Person.LastName) && p.GetMaxLength() == Constants.DefaultNameLength && (bool)p.IsUnicode()! && !p.IsNullable);
            properties.Should().Contain(p => p.Name == nameof(Person.FirstName) && p.GetMaxLength() == Constants.DefaultNameLength && (bool)p.IsUnicode()! && !p.IsNullable);
            properties.Should().Contain(p => p.Name == nameof(Person.MiddleName) && p.GetMaxLength() == Constants.DefaultNameLength && (bool)p.IsUnicode()! && p.IsNullable);
            properties.Should().Contain(p => p.Name == nameof(Person.EnglishName) && p.GetMaxLength() == Constants.DefaultNameLength && (bool)p.IsUnicode()! && p.IsNullable);
            properties.Should().Contain(p => p.Name == nameof(Person.SocialSecurityNumber) && p.GetMaxLength() == Constants.DefaultSocialSecurityNumberLength && (bool)(!p.IsUnicode())! && p.IsNullable);
            properties.Should().Contain(p => p.Name == nameof(Person.DateOfBirth) && p.IsNullable);
            properties.Should().Contain(p => p.Name == nameof(Person.IsMale) && !p.IsNullable);
            properties.Should().Contain(p => p.Name == nameof(Person.LastNameFirst) && !p.IsNullable);
        }
    }
}