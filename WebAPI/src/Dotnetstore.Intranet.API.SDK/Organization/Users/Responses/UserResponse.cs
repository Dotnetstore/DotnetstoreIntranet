namespace Dotnetstore.Intranet.API.SDK.Organization.Users.Responses;

public record struct UserResponse(
    Guid Id, 
    string LastName, 
    string FirstName, 
    string? MiddleName,
    string? EnglishName,
    string? SocialSecurityNumber,
    DateTime? DateOfBirth,
    bool IsMale,
    bool LastNameFirst,
    bool IsBlocked,
    bool IsDeleted,
    List<string> UserGroups,
    List<string> UserRoles,
    List<string> UserEmails);