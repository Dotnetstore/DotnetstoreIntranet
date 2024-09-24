using Dotnetstore.Intranet.API.SharedKernel.Services;
using FluentAssertions;
using Xunit;

namespace Dotnetstore.Intranet.API.SharedKernel.Tests.Services;

public class EnumerationTests
{
    private class TestEnumeration(Guid id, string name) : Enumeration(id, name)
    {
        public static readonly TestEnumeration Value1 = new(Guid.NewGuid(), "Value1");
        public static readonly TestEnumeration Value2 = new(Guid.NewGuid(), "Value2");
    }

    [Fact]
    public void Properties_SetAndGet_ReturnsCorrectValues()
    {
        // Arrange
        var id = Guid.NewGuid();
        const string name = "TestName";
        var enumeration = new TestEnumeration(id, name);

        // Act & Assert
        enumeration.Id.Should().Be(id);
        enumeration.Name.Should().Be(name);
    }

    [Fact]
    public void ToString_ReturnsCorrectName()
    {
        // Arrange
        var enumeration = TestEnumeration.Value1;

        // Act
        var result = enumeration.ToString();

        // Assert
        result.Should().Be(enumeration.Name);
    }

    [Fact]
    public void CompareTo_SameId_ReturnsZero()
    {
        // Arrange
        var id = Guid.NewGuid();
        var enumeration1 = new TestEnumeration(id, "Name1");
        var enumeration2 = new TestEnumeration(id, "Name2");

        // Act
        var result = enumeration1.CompareTo(enumeration2);

        // Assert
        result.Should().Be(0);
    }

    [Fact]
    public void CompareTo_DifferentId_ReturnsNonZero()
    {
        // Arrange
        var enumeration1 = TestEnumeration.Value1;
        var enumeration2 = TestEnumeration.Value2;

        // Act
        var result = enumeration1.CompareTo(enumeration2);

        // Assert
        result.Should().NotBe(0);
    }

    [Fact]
    public void GetAll_ReturnsAllInstances()
    {
        // Act
        var result = Enumeration.GetAll<TestEnumeration>();

        // Assert
        result.Should().Contain(new[] { TestEnumeration.Value1, TestEnumeration.Value2 });
    }

    [Fact]
    public void Equals_SameId_ReturnsTrue()
    {
        // Arrange
        var id = Guid.NewGuid();
        var enumeration1 = new TestEnumeration(id, "Name1");
        var enumeration2 = new TestEnumeration(id, "Name2");

        // Act
        var result = enumeration1.Equals(enumeration2);

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void Equals_DifferentId_ReturnsFalse()
    {
        // Arrange
        var enumeration1 = TestEnumeration.Value1;
        var enumeration2 = TestEnumeration.Value2;

        // Act
        var result = enumeration1.Equals(enumeration2);

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void GetHashCode_SameId_ReturnsSameHashCode()
    {
        // Arrange
        var id = Guid.NewGuid();
        var enumeration1 = new TestEnumeration(id, "Name1");
        var enumeration2 = new TestEnumeration(id, "Name2");

        // Act
        var hashCode1 = enumeration1.GetHashCode();
        var hashCode2 = enumeration2.GetHashCode();

        // Assert
        hashCode1.Should().Be(hashCode2);
    }

    [Fact]
    public void FromValue_ValidValue_ReturnsCorrectInstance()
    {
        // Act
        var result = Enumeration.FromValue<TestEnumeration>(TestEnumeration.Value1.Id);

        // Assert
        result.Should().Be(TestEnumeration.Value1);
    }

    [Fact]
    public void FromDisplayName_ValidName_ReturnsCorrectInstance()
    {
        // Act
        var result = Enumeration.FromDisplayName<TestEnumeration>(TestEnumeration.Value1.Name);

        // Assert
        result.Should().Be(TestEnumeration.Value1);
    }
}