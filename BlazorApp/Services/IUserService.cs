namespace BlazorApp.Services
{
    public interface IUserService
    {
        System.Threading.Tasks.Task<Data.User> LoginAsync(Data.User user);
        //System.Threading.Tasks.Task<Data.User> RegisterUserAsync(Data.User user);
        //System.Threading.Tasks.Task<Data.User> GetUserByAccessTokenAsync(string accessToken);
        //System.Threading.Tasks.Task<Data.User> RefreshTokenAsync(RefreshRequest refreshRequest);
    }
}
