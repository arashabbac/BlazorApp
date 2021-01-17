namespace BlazorApp.Data
{
    public class CustomAuthenticationStateProvider  : Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider
    {
        private Blazored.SessionStorage.ISessionStorageService _sessionStorageService;
        public CustomAuthenticationStateProvider(Blazored.SessionStorage.ISessionStorageService sessionStorageService)
        {
            _sessionStorageService = sessionStorageService;
        }

        public async override System.Threading.Tasks.Task
            <Microsoft.AspNetCore.Components.Authorization.AuthenticationState>
            GetAuthenticationStateAsync()
        {

            var emailAddress = await _sessionStorageService.GetItemAsync<string>("emailAddress");

            System.Security.Claims.ClaimsIdentity identity;

            if(emailAddress != null)
            {
                identity = new System.Security.Claims.ClaimsIdentity(new[]
                {
                    new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.Name , emailAddress),
                }, "apiauth_type");
            }
            else
            {
                identity = new System.Security.Claims.ClaimsIdentity();
            }

            var user = new System.Security.Claims.ClaimsPrincipal(identity);

            return await System.Threading.Tasks.Task.
                FromResult(new Microsoft.AspNetCore.Components.Authorization.AuthenticationState(user));
        }

        public void MarkUserAsAuthenticated(string emailAddress)
        {
            var identity = new System.Security.Claims.ClaimsIdentity(new[]
            {
                new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.Name , emailAddress),
            }, "apiauth_type");

            var user = new System.Security.Claims.ClaimsPrincipal(identity);

            NotifyAuthenticationStateChanged( System.Threading.Tasks.Task.
                FromResult(new Microsoft.AspNetCore.Components.Authorization.AuthenticationState(user))) ;
        }

        public void MarkUserAsLoggedOut()
        {
            _sessionStorageService.RemoveItemAsync("emailAddress");
            _sessionStorageService.RemoveItemAsync("token");

            var identity = new System.Security.Claims.ClaimsIdentity();

            var user = new System.Security.Claims.ClaimsPrincipal(identity);

            NotifyAuthenticationStateChanged(System.Threading.Tasks.Task
                .FromResult(new Microsoft.AspNetCore.Components.Authorization.AuthenticationState(user)));
        }
    }
}
