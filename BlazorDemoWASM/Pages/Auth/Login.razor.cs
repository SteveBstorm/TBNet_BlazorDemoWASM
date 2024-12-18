using BlazorDemoWASM.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using System.Net.Http.Json;

namespace BlazorDemoWASM.Pages.Auth
{
    public partial class Login
    {
        public LoginForm loginForm { get; set; } = new LoginForm();

        [Inject]
        public HttpClient Client { get; set; }
        [Inject]
        public IJSRuntime JSRuntime { get; set; }
        [Inject]
        public AuthenticationStateProvider StateProvider { get; set; }

        public async Task SubmitLogin()
        {
            
            HttpResponseMessage response = await Client.PostAsJsonAsync("auth", loginForm);
            if (!response.IsSuccessStatusCode)
            {
                await Console.Out.WriteLineAsync("Erreur : " + response.ReasonPhrase);
            }

            string token = await response.Content.ReadAsStringAsync();
            await JSRuntime.InvokeVoidAsync("localStorage.setItem", "token", token);
            ((MyAuthStateProvider)StateProvider).NotifyUserChanged();
        }
    }
}
