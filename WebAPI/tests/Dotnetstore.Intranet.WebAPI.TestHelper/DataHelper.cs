using Microsoft.EntityFrameworkCore;

namespace Dotnetstore.Intranet.WebAPI.TestHelper;

public static class DataHelper
{
    public static DbContextOptions<T> CreateOptions<T>() where T : DbContext
    {
        return new DbContextOptionsBuilder<T>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
    }
}