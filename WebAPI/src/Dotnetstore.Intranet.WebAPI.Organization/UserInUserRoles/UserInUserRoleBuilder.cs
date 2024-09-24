using Dotnetstore.Intranet.WebAPI.Organization.UserRoles;
using Dotnetstore.Intranet.WebAPI.Organization.Users;

namespace Dotnetstore.Intranet.WebAPI.Organization.UserInUserRoles;

internal sealed class UserInUserRoleBuilder : 
    ICreateUserInUserRoleId, 
    ICreateUserInUserRoleObject,  
    ICreateMetaData, 
    IBuildUserInUserRole
{
    private UserInUserRoleId _id;
    private UserId _userId;
    private UserRoleId _userRoleId;
    private Guid? _createdBy;
    private DateTimeOffset _createdDate;
    private Guid? _lastUpdatedBy;
    private DateTimeOffset? _lastUpdatedDate;
    private bool _isDeleted;
    private Guid? _deletedBy;
    private DateTimeOffset? _deletedDate;
    private bool _isSystem;
    private bool _isGdpr;

    private UserInUserRoleBuilder() { }

    internal static ICreateUserInUserRoleId Create()
    {
        return new UserInUserRoleBuilder();
    }
    
    ICreateUserInUserRoleObject ICreateUserInUserRoleId.CreateId()
    {
        _id = new UserInUserRoleId(Guid.NewGuid());
        return this;
    }

    ICreateMetaData ICreateUserInUserRoleObject.CreateObjectData(
        UserId userId, 
        UserRoleId userRoleId)
    {
        _userId = userId;
        _userRoleId = userRoleId;
        return this;
    }

    IBuildUserInUserRole ICreateMetaData.CreateMetadata()
    {
        _createdDate = DateTimeOffset.Now;
        _createdBy = null;
        _lastUpdatedBy = null;
        _lastUpdatedDate = null;
        _isDeleted = false;
        _deletedBy = null;
        _deletedDate = null;
        _isSystem = false;
        _isGdpr = false;
        return this;
    }

    UserInUserRole IBuildUserInUserRole.Build()
    {
        return new UserInUserRole
        {
            Id = _id,
            UserId = _userId,
            UserRoleId = _userRoleId,
            CreatedBy = _createdBy,
            CreatedDate = _createdDate,
            LastUpdatedBy = _lastUpdatedBy,
            LastUpdatedDate = _lastUpdatedDate,
            IsDeleted = _isDeleted,
            DeletedBy = _deletedBy,
            DeletedDate = _deletedDate,
            IsSystem = _isSystem,
            IsGdpr = _isGdpr
        };
    }
}

internal interface ICreateUserInUserRoleId
{
    ICreateUserInUserRoleObject CreateId();
}

internal interface ICreateUserInUserRoleObject
{
    ICreateMetaData CreateObjectData(UserId userId, UserRoleId userRoleId);
}

internal interface ICreateMetaData
{
    IBuildUserInUserRole CreateMetadata();
}

internal interface IBuildUserInUserRole
{
    UserInUserRole Build();
}