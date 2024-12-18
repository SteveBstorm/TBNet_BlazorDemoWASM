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
   Pour intégrer l'authentification 
   1) Créer un composant Login permettant de se connecter et récupérer le token dans l'api
   2) Créer le stateProvider qui vérifie l'existence du token et transmet l'utilisateur connecté à l'app
   3) Modifier app.razor pour fournir l'état grâce à <CascadingStateProvider>
   4) Injecter le state provider en singleton dans le program.cs
   5) Ajouter builder.Services.AddAuthorizationCore(); dans le program.cs
   6) Utilisation de @attribute [Authorize] pour limiter l'accès aux pages
            [Authorize(Roles = "...")] Si limité à un rôle particulier

   7) Utilisation de <AuthorizeView> + <Authorized> & <NotAuthorized> 
    => Permet de cacher/afficher une partie de la vue/composant en fonction de l'état de connexion
 */

await builder.Build().RunAsync();
