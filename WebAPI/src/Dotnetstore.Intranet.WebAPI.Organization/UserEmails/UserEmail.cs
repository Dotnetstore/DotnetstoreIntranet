using Dotnetstore.Intranet.WebAPI.Organization.Enums;
using Dotnetstore.Intranet.WebAPI.Organization.Users;
using Dotnetstore.Intranet.WebAPI.Utility.Entities;

namespace Dotnetstore.Intranet.WebAPI.Organization.UserEmails;

internal sealed class UserEmail : BaseAuditableEntity
{
    public UserEmailId UserEmailId { get; set; }
    
    public UserId UserId { get; set; }
    
    public EmailType EmailType { get; set; } = null!;

    public string EmailAddress { get; set; } = null!;

    public User User { get; set; } = null!;
}

internal record struct UserEmailId(Guid Value);