using FastEndpoints.Testing;
using Testcontainers.MsSql;
using Testcontainers.PostgreSql;

namespace Dotnetstore.Intranet.WebAPI.TestHelper.Abstracts;

public class DotnetstoreIntranetBase : AppFixture<Program>
{
    // private IServiceCollection _serviceCollection = null!;
    protected readonly MsSqlContainer DatabaseContainer = new MsSqlBuilder().Build();

    protected override async Task PreSetupAsync()
    {
        await DatabaseContainer.StartAsync();
    }

    protected override async Task TearDownAsync()
    {
        await DatabaseContainer.StopAsync();
    }
}