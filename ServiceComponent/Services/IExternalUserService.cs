//using ServiceComponent.Models

public interface IExternalUserService
{
    Task<User?> GetUserByIdAsync(int userId);
    Task<IEnumerable<User>> GetAllUsersAsync();
}

