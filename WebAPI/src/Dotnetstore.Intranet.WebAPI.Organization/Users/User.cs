using Dotnetstore.Intranet.WebAPI.Utility.Entities;

namespace Dotnetstore.Intranet.WebAPI.Organization.Users;

internal sealed class User : Identity
{
    public UserId UserId { get; set; }

    // public ICollection<EmailVerificationToken> EmailVerificationTokens { get; set; } = new List<EmailVerificationToken>();
    //
    // public ICollection<UserInUserRole> UserInUserRoles { get; set; } = new List<UserInUserRole>();
    //
    // public ICollection<UserInUserGroup> UserInUserGroups { get; set; } = new List<UserInUserGroup>();
}

internal record struct UserId(Guid Value);