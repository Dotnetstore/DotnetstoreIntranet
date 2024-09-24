using Dotnetstore.Intranet.API.Organization.EmailVerificationTokens;
using Dotnetstore.Intranet.API.Organization.UserEmails;
using Dotnetstore.Intranet.API.Organization.UserInUserGroups;
using Dotnetstore.Intranet.API.Organization.UserInUserRoles;
using Dotnetstore.Intranet.API.SharedKernel.Entities;

namespace Dotnetstore.Intranet.API.Organization.Users;

internal sealed class User : Identity
{
    public UserId UserId { get; set; }

    public ICollection<EmailVerificationToken> EmailVerificationTokens { get; set; } = new List<EmailVerificationToken>();
    
    public ICollection<UserInUserRole> UserInUserRoles { get; set; } = new List<UserInUserRole>();
    
    public ICollection<UserInUserGroup> UserInUserGroups { get; set; } = new List<UserInUserGroup>();
    
    public ICollection<UserEmail> UserEmails { get; set; } = new List<UserEmail>();
}

internal record struct UserId(Guid Value);