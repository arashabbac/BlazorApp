namespace BlazorApp.Services
{
    public class BookStoreService<T> : IBookStoreService<T>
    {

        public System.Net.Http.HttpClient _httpClient { get; }
        public Data.AppSettings _appSettings { get; }
        public Blazored.SessionStorage.ISessionStorageService _sessionStorageService { get; }

        public BookStoreService(System.Net.Http.HttpClient httpClient , 
            Microsoft.Extensions.Options.IOptions<Data.AppSettings> appSettings,
            Blazored.SessionStorage.ISessionStorageService sessionStorageService)
        {
            _appSettings = appSettings.Value;
            _sessionStorageService = sessionStorageService;

            httpClient.BaseAddress = new System.Uri(_appSettings.BookStoresBaseAddress);
            httpClient.DefaultRequestHeaders.Add("User-Agent", "BlazorServer");

            _httpClient = httpClient;
        }


        public async System.Threading.Tasks.Task<bool> DeleteAsync(string requestUri, int Id)
        {
            var requestMessage = new System.Net.Http.HttpRequestMessage(System.Net.Http.HttpMethod.Delete, requestUri + Id);

            var token = await _sessionStorageService.GetItemAsync<string>("accessToken");
            requestMessage.Headers.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.SendAsync(requestMessage);
            var responseStatusCode = response.StatusCode;

            return await System.Threading.Tasks.Task.FromResult(true);

        }

        public async System.Threading.Tasks.Task<System.Collections.Generic.List<T>> GetAllAsync(string requestUri)
        {
            var requestMessage =
                new System.Net.Http.HttpRequestMessage(System.Net.Http.HttpMethod.Get, requestUri);

            var token = await _sessionStorageService.GetItemAsync<string>("accessToken");
            requestMessage.Headers.Authorization = 
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var response =
                await _httpClient.SendAsync(requestMessage);

            var responseStatusCode = response.StatusCode;
            if(responseStatusCode.ToString() == "OK")
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                return await System.Threading.Tasks.Task.FromResult
                    (Newtonsoft.Json.JsonConvert.DeserializeObject<System.Collections.Generic.List<T>>(responseBody));
            }
            else
            {
                return null;
            }
        }

        public async System.Threading.Tasks.Task<T> GetAllByIdAsync(string requestUri, int Id)
        {
            var requestMessage = new System.Net.Http.HttpRequestMessage(System.Net.Http.HttpMethod.Get, requestUri + Id);

            var token = await _sessionStorageService.GetItemAsync<string>("accessToken");
            requestMessage.Headers.Authorization
                            = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.SendAsync(requestMessage);

            var responseStatusCode = response.StatusCode;
            var responseBody = await response.Content.ReadAsStringAsync();

            return await System.Threading.Tasks.Task.FromResult
                (Newtonsoft.Json.JsonConvert.DeserializeObject<T>(responseBody));
        }

        public async System.Threading.Tasks.Task<T> SaveAsync(string requestUri, T obj)
        {
            string serializedUser = 
                Newtonsoft.Json.JsonConvert.SerializeObject(obj);

            var requestMessage = 
                new System.Net.Http.HttpRequestMessage(System.Net.Http.HttpMethod.Post, requestUri);

            var token = await _sessionStorageService.GetItemAsync<string>("accessToken");
            requestMessage.Headers.Authorization
                                = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            requestMessage.Content = new System.Net.Http.StringContent(serializedUser);

            requestMessage.Content.Headers.ContentType
                = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var response = await _httpClient.SendAsync(requestMessage);

            var responseStatusCode = response.StatusCode;
            var responseBody = await response.Content.ReadAsStringAsync();

            var returnedObj = 
                Newtonsoft.Json.JsonConvert.DeserializeObject<T>(responseBody);

            return await System.Threading.Tasks.Task.FromResult(returnedObj);
        }

        public async System.Threading.Tasks.Task<T> UpdateAsync(string requestUri, int Id, T obj)
        {
            string serializedUser =
                    Newtonsoft.Json.JsonConvert.SerializeObject(obj);

            var requestMessage =
                new System.Net.Http.HttpRequestMessage(System.Net.Http.HttpMethod.Put, requestUri + Id);

            var token = await _sessionStorageService.GetItemAsync<string>("accessToken");
            requestMessage.Headers.Authorization
                                = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            requestMessage.Content = new System.Net.Http.StringContent(serializedUser);

            requestMessage.Content.Headers.ContentType
                = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var response = await _httpClient.SendAsync(requestMessage);

            var responseStatusCode = response.StatusCode;
            var responseBody = await response.Content.ReadAsStringAsync();

            var returnedObj =
                Newtonsoft.Json.JsonConvert.DeserializeObject<T>(responseBody);

            return await System.Threading.Tasks.Task.FromResult(returnedObj);
        }
    }
}
