// using Dotnetstore.Intranet.WebAPI.Organization.EmailVerificationTokens;
// using Dotnetstore.Intranet.WebAPI.Organization.UserEmails;
// using Dotnetstore.Intranet.WebAPI.Organization.UserInUserGroups;
// using Dotnetstore.Intranet.WebAPI.Organization.UserInUserRoles;
// using Dotnetstore.Intranet.WebAPI.Utility.Entities;
//
// namespace Dotnetstore.Intranet.WebAPI.Organization.Users;
//
// internal sealed class User : Identity
// {
//     public UserId UserId { get; set; }
//
//     public ICollection<EmailVerificationToken> EmailVerificationTokens { get; set; } = new List<EmailVerificationToken>();
//     
//     public ICollection<UserInUserRole> UserInUserRoles { get; set; } = new List<UserInUserRole>();
//     
//     public ICollection<UserInUserGroup> UserInUserGroups { get; set; } = new List<UserInUserGroup>();
//     
//     public ICollection<UserEmail> UserEmails { get; set; } = new List<UserEmail>();
// }
//
// internal record struct UserId(Guid Value);