using System.Reflection.Metadata;
using ServiceComponent.Client;

public class ExternalUserService : IExternalUserService
{
    private readonly IComponentClient _client;
public ExternalUserService(IComponentClient client)
    {
        _client = client;
    }

    public Task<User?> GetUserByIdAsync(int userId)
    {
        return _client.GetUserByIdAsync(userId);
    }

    public Task<IEnumerable<User>> GetAllUsersAsync()
    {
        return _client.GetAllUsersAsync();
    }
}