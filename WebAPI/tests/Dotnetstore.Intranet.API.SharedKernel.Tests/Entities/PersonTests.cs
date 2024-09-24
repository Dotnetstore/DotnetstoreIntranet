using Dotnetstore.Intranet.API.SharedKernel.Entities;
using FluentAssertions;
using Xunit;

namespace Dotnetstore.Intranet.API.SharedKernel.Tests.Entities;

public class PersonTests
{
    private class TestPerson : Person;

    [Fact]
    public void Properties_SetAndGet_ReturnsCorrectValues()
    {
        // Arrange
        var person = new TestPerson();
        const string lastName = "Doe";
        const string firstName = "John";
        const string middleName = "A.";
        const string englishName = "Johnny";
        const string ssn = "123-45-6789";
        var dob = new DateTime(1990, 1, 1);
        const bool isMale = true;
        const bool lastNameFirst = true;

        // Act
        person.LastName = lastName;
        person.FirstName = firstName;
        person.MiddleName = middleName;
        person.EnglishName = englishName;
        person.SocialSecurityNumber = ssn;
        person.DateOfBirth = dob;
        person.IsMale = isMale;
        person.LastNameFirst = lastNameFirst;

        // Assert
        using (new FluentAssertions.Execution.AssertionScope())
        {
            person.LastName.Should().Be(lastName);
            person.FirstName.Should().Be(firstName);
            person.MiddleName.Should().Be(middleName);
            person.EnglishName.Should().Be(englishName);
            person.SocialSecurityNumber.Should().Be(ssn);
            person.DateOfBirth.Should().Be(dob);
            person.IsMale.Should().Be(isMale);
            person.LastNameFirst.Should().Be(lastNameFirst);
        }
    }

    [Fact]
    public void ToString_ReturnsCorrectFormattedString()
    {
        // Arrange
        var person = new TestPerson
        {
            LastName = "Doe",
            FirstName = "John",
            MiddleName = "A.",
            EnglishName = "Johnny",
            LastNameFirst = true
        };

        // Act
        var result = person.ToString();

        // Assert
        result.Should().Be("Doe, John A. (Johnny)");

        // Arrange
        person.LastNameFirst = false;

        // Act
        result = person.ToString();

        // Assert
        result.Should().Be("John A. Doe (Johnny)");
    }
}