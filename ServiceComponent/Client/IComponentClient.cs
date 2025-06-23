
namespace ServiceComponent.Client{
public interface IComponentClient
{
    Task<User?> GetUserByIdAsync(int userId);
    Task<IEnumerable<User>> GetAllUsersAsync();
}

}