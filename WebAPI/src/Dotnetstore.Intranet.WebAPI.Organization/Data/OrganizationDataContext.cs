// using Dotnetstore.Intranet.WebAPI.Organization.EmailVerificationTokens;
// using Dotnetstore.Intranet.WebAPI.Organization.UserEmails;
// using Dotnetstore.Intranet.WebAPI.Organization.UserGroups;
// using Dotnetstore.Intranet.WebAPI.Organization.UserInUserGroups;
// using Dotnetstore.Intranet.WebAPI.Organization.UserInUserRoles;
// using Dotnetstore.Intranet.WebAPI.Organization.UserRoles;
// using Dotnetstore.Intranet.WebAPI.Organization.UserRolesInUserGroups;
// using Dotnetstore.Intranet.WebAPI.Organization.Users;
// using Dotnetstore.Intranet.WebAPI.Utility.Abstracts;
// using Microsoft.EntityFrameworkCore;
//
// namespace Dotnetstore.Intranet.WebAPI.Organization.Data;
//
// internal sealed class OrganizationDataContext(DbContextOptions<OrganizationDataContext> options) : ApiContext<OrganizationDataContext>(options)
// {
//     internal DbSet<EmailVerificationToken> EmailVerificationTokens => Set<EmailVerificationToken>();
//     
//     internal DbSet<UserEmail> UserEmails => Set<UserEmail>();
//     
//     internal DbSet<UserGroup> UserGroups => Set<UserGroup>();
//     
//     internal DbSet<UserInUserGroup> UserInUserGroups => Set<UserInUserGroup>();
//     
//     internal DbSet<UserInUserRole> UserInUserRoles => Set<UserInUserRole>();
//     
//     internal DbSet<UserRole> UserRoles => Set<UserRole>();
//     
//     internal DbSet<UserRoleInUserGroup> UserRoleInUserGroups => Set<UserRoleInUserGroup>();
//     
//     internal DbSet<User> Users => Set<User>();
//     
//     protected override void OnModelCreating(ModelBuilder modelBuilder)
//     {
//         base.OnModelCreating(modelBuilder);
//         
//         modelBuilder.HasDefaultSchema("Organization");
//         modelBuilder.ApplyConfigurationsFromAssembly(typeof(IOrganizationAssemblyMarker).Assembly);
//     }
// }