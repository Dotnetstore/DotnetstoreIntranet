namespace Dotnetstore.Intranet.WebAPI.Organization.Users;

internal interface IUserRepository
{
    ValueTask<List<User>> GetAllNotSystemAsync(CancellationToken ct);
    
    ValueTask<User?> GetByUsernameAsync(string username, CancellationToken cancellationToken);
    
    ValueTask<User?> GetByIdAsync(UserId userId, CancellationToken cancellationToken);
    
    void Create(User user);
    
    ValueTask SaveChangesAsync(CancellationToken ct);
}