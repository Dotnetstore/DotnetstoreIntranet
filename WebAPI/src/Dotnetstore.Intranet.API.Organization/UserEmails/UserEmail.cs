using Dotnetstore.Intranet.API.Organization.Enums;
using Dotnetstore.Intranet.API.Organization.Users;
using Dotnetstore.Intranet.API.SharedKernel.Entities;

namespace Dotnetstore.Intranet.API.Organization.UserEmails;

internal sealed class UserEmail : BaseAuditableEntity
{
    public UserEmailId UserEmailId { get; set; }
    
    public UserId UserId { get; set; }
    
    public EmailType EmailType { get; set; } = null!;

    public string EmailAddress { get; set; } = null!;

    public User User { get; set; } = null!;
}

internal record struct UserEmailId(Guid Value);