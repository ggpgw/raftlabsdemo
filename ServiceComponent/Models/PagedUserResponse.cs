public class PagedUserResponse
{
    public int Page { get; set; }
    public int TotalPages { get; set; }
    public List<User> Data { get; set; } = new();
}