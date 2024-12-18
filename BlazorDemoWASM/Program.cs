using BlazorDemoWASM;
using BlazorDemoWASM.Pages.Auth;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddTransient<TokenInterceptor>();

builder.Services.AddHttpClient("clientWithToken", sp =>
{
    new HttpClient();
    sp.BaseAddress = new Uri("https://localhost:7010/api/");
}).AddHttpMessageHandler<TokenInterceptor>();

//builder.Services.AddHttpClient("client2", sp =>
//{
//    new HttpClient { BaseAddress = new Uri("https://localhost:7010/api/") };
//}).AddHttpMessageHandler<TokenInterceptor>();

builder.Services.AddScoped<HttpClient>(sp => sp.GetRequiredService<IHttpClientFactory>()
                                    .CreateClient("clientWithToken"));



builder.Services.AddAuthorizationCore();
builder.Services.AddSingleton<AuthenticationStateProvider, MyAuthStateProvider>();
/*

 * 
   Pour int�grer l'authentification 
   1) Cr�er un composant Login permettant de se connecter et r�cup�rer le token dans l'api
   2) Cr�er le stateProvider qui v�rifie l'existence du token et transmet l'utilisateur connect� � l'app
   3) Modifier app.razor pour fournir l'�tat gr�ce � <CascadingStateProvider>
   4) Injecter le state provider en singleton dans le program.cs
   5) Ajouter builder.Services.AddAuthorizationCore(); dans le program.cs
   6) Utilisation de @attribute [Authorize] pour limiter l'acc�s aux pages
            [Authorize(Roles = "...")] Si limit� � un r�le particulier

   7) Utilisation de <AuthorizeView> + <Authorized> & <NotAuthorized> 
    => Permet de cacher/afficher une partie de la vue/composant en fonction de l'�tat de connexion
 */

await builder.Build().RunAsync();
