using Microsoft.JSInterop;

namespace BlazorDemoWASM.Pages.Auth
{
    public class TokenInterceptor(IJSRuntime js): DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            await Console.Out.WriteLineAsync("Intercepte");
            string token = await js.InvokeAsync<string>("localStorage.getItem", "token");
            if(!string.IsNullOrEmpty(token))
            {
                request.Headers.Add("Authorization", "bearer " + token);
            }
            return await base.SendAsync(request, cancellationToken);
        }
    }
}
