using System.ComponentModel.DataAnnotations;
using Dotnetstore.Intranet.API.SharedKernel.Entities;
using Dotnetstore.Intranet.API.SharedKernel.Repositories;
using FluentAssertions;
using FluentAssertions.Execution;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Dotnetstore.Intranet.API.SharedKernel.Tests.Repositories;

public class GenericRepositoryTests
{
    private class TestEntity : BaseAuditableEntity
    {
        [Key] 
        public Guid Id { get; set; }
        
        public string Name { get; set; } = null!;
    }

    private class TestDbContext(DbContextOptions<TestDbContext> options) : DbContext(options)
    {
        public DbSet<TestEntity> TestEntities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TestEntity>().HasKey(e => e.Id);
        }
    }

    private static IGenericRepository<TestEntity> CreateRepository(TestDbContext context)
    {
        return new GenericRepository<TestEntity>(context);
    }

    [Fact]
    public async Task GetByIdAsync_ReturnsCorrectEntity()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<TestDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        await using var context = new TestDbContext(options);
        var repository = CreateRepository(context);
        var entity = new TestEntity { Id = Guid.NewGuid(), Name = "Test" };
        context.TestEntities.Add(entity);
        await context.SaveChangesAsync();

        // Act
        var result = await repository.GetByIdAsync(entity.Id);

        // Assert
        using (new AssertionScope())
        {
            result.Should().NotBeNull();
            result!.Id.Should().Be(entity.Id);
            result.Name.Should().Be(entity.Name);
        }
    }

    [Fact]
    public async Task GetAllAsync_ReturnsAllEntities()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<TestDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        await using var context = new TestDbContext(options);
        var repository = CreateRepository(context);
        var entities = new List<TestEntity>
        {
            new TestEntity { Id = Guid.NewGuid(), Name = "Test1" },
            new TestEntity { Id = Guid.NewGuid(), Name = "Test2" }
        };
        context.TestEntities.AddRange(entities);
        await context.SaveChangesAsync();

        // Act
        var result = await repository.GetAllAsync();

        // Assert
        using (new AssertionScope())
        {
            result.Should().HaveCount(2);
            result.Should().Contain(e => e.Name == "Test1");
            result.Should().Contain(e => e.Name == "Test2");
        }
    }

    [Fact]
    public async Task Create_AddsNewEntity()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<TestDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        await using var context = new TestDbContext(options);
        var repository = CreateRepository(context);
        var entity = new TestEntity { Id = Guid.NewGuid(), Name = "Test" };

        // Act
        repository.Create(entity);
        await context.SaveChangesAsync();

        // Assert
        context.TestEntities.Should().Contain(e => e.Name == "Test");
    }

    [Fact]
    public async Task Update_ModifiesExistingEntity()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<TestDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        await using var context = new TestDbContext(options);
        var repository = CreateRepository(context);
        var entity = new TestEntity { Id = Guid.NewGuid(), Name = "Test" };
        context.TestEntities.Add(entity);
        await context.SaveChangesAsync();

        // Act
        entity.Name = "UpdatedTest";
        repository.Update(entity);
        await context.SaveChangesAsync();

        // Assert
        context.TestEntities.Should().Contain(e => e.Name == "UpdatedTest");
    }

    [Fact]
    public async Task Delete_RemovesEntity()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<TestDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        await using var context = new TestDbContext(options);
        var repository = CreateRepository(context);
        var entity = new TestEntity { Id = Guid.NewGuid(), Name = "Test" };
        context.TestEntities.Add(entity);
        await context.SaveChangesAsync();

        // Act
        repository.Delete(entity);
        await context.SaveChangesAsync();

        // Assert
        context.TestEntities.Should().NotContain(e => e.Name == "Test");
    }
}