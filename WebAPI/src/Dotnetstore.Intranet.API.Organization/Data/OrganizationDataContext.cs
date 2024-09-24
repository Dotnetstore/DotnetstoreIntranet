using Dotnetstore.Intranet.API.Organization.EmailVerificationTokens;
using Dotnetstore.Intranet.API.Organization.UserEmails;
using Dotnetstore.Intranet.API.Organization.UserGroups;
using Dotnetstore.Intranet.API.Organization.UserInUserGroups;
using Dotnetstore.Intranet.API.Organization.UserInUserRoles;
using Dotnetstore.Intranet.API.Organization.UserRoles;
using Dotnetstore.Intranet.API.Organization.UserRolesInUserGroups;
using Dotnetstore.Intranet.API.Organization.Users;
using Dotnetstore.Intranet.API.SharedKernel.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace Dotnetstore.Intranet.API.Organization.Data;

internal sealed class OrganizationDataContext(DbContextOptions<OrganizationDataContext> options) : ApiContext<OrganizationDataContext>(options)
{
    internal DbSet<EmailVerificationToken> EmailVerificationTokens => Set<EmailVerificationToken>();
    
    internal DbSet<UserEmail> UserEmails => Set<UserEmail>();
    
    internal DbSet<UserGroup> UserGroups => Set<UserGroup>();
    
    internal DbSet<UserInUserGroup> UserInUserGroups => Set<UserInUserGroup>();
    
    internal DbSet<UserInUserRole> UserInUserRoles => Set<UserInUserRole>();
    
    internal DbSet<UserRole> UserRoles => Set<UserRole>();
    
    internal DbSet<UserRoleInUserGroup> UserRoleInUserGroups => Set<UserRoleInUserGroup>();
    
    internal DbSet<User> Users => Set<User>();
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.HasDefaultSchema("Organization");
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(IOrganizationAssemblyMarker).Assembly);
    }
}