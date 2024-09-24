// using Dotnetstore.Intranet.WebAPI.Organization.Data;
// using Dotnetstore.Intranet.WebAPI.TestHelper.Abstracts;
// using Dotnetstore.Intranet.WebAPI.Utility.Extensions;
// using Microsoft.AspNetCore.Hosting;
// using Microsoft.AspNetCore.TestHost;
//
// namespace Dotnetstore.Intranet.WebAPI.Organization.Tests.Integration;
//
// public class DotnetstoreIntranetOrganizationBase : DotnetstoreIntranetBase
// {
//     protected override void ConfigureApp(IWebHostBuilder a)
//     {
//         // PostgreSqlContainer.StartAsync().ConfigureAwait(false).GetAwaiter().GetResult();
//         
//         a.ConfigureTestServices(x =>
//         {
//             x.RemoveDbContext<OrganizationDataContext>();
//             x.AddDbContext<OrganizationDataContext>(DatabaseContainer.GetConnectionString(), true, false);
//             x.EnsureDbCreated<OrganizationDataContext>();
//         });
//     }
// }