using Dotnetstore.Intranet.API.Organization.UserGroups;
using Dotnetstore.Intranet.API.Organization.Users;
using Dotnetstore.Intranet.API.SharedKernel.Entities;

namespace Dotnetstore.Intranet.API.Organization.UserInUserGroups;

internal sealed class UserInUserGroup : BaseAuditableEntity
{
    public UserInUserGroupId Id { get; set; }

    public UserId UserId { get; set; }

    public UserGroupId UserGroupId { get; set; }

    public User User { get; set; } = null!;

    public UserGroup UserGroup { get; set; } = null!;
}

internal record struct UserInUserGroupId(Guid Value);