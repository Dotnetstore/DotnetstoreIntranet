using Dotnetstore.Intranet.API.Organization.Users;
using Dotnetstore.Intranet.API.SharedKernel.Entities;

namespace Dotnetstore.Intranet.API.Organization.EmailVerificationTokens;

internal sealed class EmailVerificationToken : BaseAuditableEntity
{
    public EmailVerificationTokenId Id { get; set; }

    public UserId UserId { get; set; }

    public DateTime ExpireDate { get; set; }

    public User User { get; set; } = null!;
}

internal record struct EmailVerificationTokenId(Guid Value);