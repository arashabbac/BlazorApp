namespace BlazorApp.Services
{
    public class UserService : IUserService
    {

        public System.Net.Http.HttpClient _httpClient { get; }

        public UserService(System.Net.Http.HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        //public System.Threading.Tasks.Task<Data.User>
        //    GetUserByAccessTokenAsync(string accessToken)
        //{
        //    throw new System.NotImplementedException();
        //}

        public async System.Threading.Tasks.Task<Data.User> 
            LoginAsync(Data.User user)
        {
            string serializedUser =
                Newtonsoft.Json.JsonConvert.SerializeObject(user);

            var requestMessage = 
                new System.Net.Http.HttpRequestMessage(System.Net.Http.HttpMethod.Post, "Login");

            requestMessage.Content = new System.Net.Http.StringContent(serializedUser);
            requestMessage.Content.Headers.ContentType =
                new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var response =
                await _httpClient.SendAsync(requestMessage);

            var responseStatusCode = response.StatusCode;
            var responseBody = 
                await response.Content.ReadAsStringAsync();

            Data.User returnedUser =
                Newtonsoft.Json.JsonConvert.DeserializeObject<Data.User>(responseBody);

            return await System.Threading.Tasks.Task.FromResult(returnedUser);

        }

        //public System.Threading.Tasks.Task<Data.User>
        //    RegisterUserAsync(Data.User user)
        //{
        //    throw new System.NotImplementedException();
        //}
    }
}
