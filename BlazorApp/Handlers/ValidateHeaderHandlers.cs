namespace BlazorApp.Handlers
{
    public class ValidateHeaderHandlers : System.Net.Http.DelegatingHandler
    {
        protected async override System.Threading.Tasks.Task<System.Net.Http.HttpResponseMessage> 
            SendAsync(System.Net.Http.HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            if (!request.Headers.Contains("Authorization"))
            {
                return new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.BadRequest);
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
