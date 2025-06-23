using System.Net.Http.Json;
using System.Net;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;

namespace ServiceComponent.Client
{
public class ComponentClient : IComponentClient
{
    private readonly HttpClient _httpClient;
    public ComponentClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

        public async Task<User?> GetUserByIdAsync(int userId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"users/{userId}");

                if (response.StatusCode == HttpStatusCode.NotFound)
                    return null;

                response.EnsureSuccessStatusCode();

                var apiresponse = await response.Content.ReadFromJsonAsync<UserResponse>();
                return apiresponse?.Data;
            }
            catch (HttpRequestException ex)
            {
                // Handle network errors (e.g., DNS failure, refused connection)
                // Log or rethrow with context
                Console.Write("Network error occurred while fetching user.");
                return null;
            }
            catch (TaskCanceledException ex) when (!ex.CancellationToken.IsCancellationRequested)
            {
                // Handle request timeout
                Console.Write("The request timed out while fetching user.");
                return null;
            }
   
    }

    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {

        var users = new List<User>();
        int page = 1;

        while (true)
        {
            var response = await _httpClient.GetAsync($"users?page={page}");
           Console.WriteLine("Request URL: " + _httpClient.BaseAddress + $"users?page={page}");
Console.WriteLine("Status Code: " + response.StatusCode);
            response.EnsureSuccessStatusCode();

            var apiResponse = await response.Content.ReadFromJsonAsync<PagedUserResponse>();
            if (apiResponse?.Data == null || apiResponse.Data.Any())
                break;

            users.AddRange(apiResponse.Data);
            if (page >= apiResponse.TotalPages) break;
            page++;

        }
        return users;
        

    }


}}