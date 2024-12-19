using BlazorDemoWASM;
using BlazorDemoWASM.Pages.Auth;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;
using System.Globalization;

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

//System.Globalization
//Microsoft.AspNetCore.Localization v2.1.0
//Microsoft.Extensions.Localization

builder.Services.AddLocalization(option => option.ResourcesPath = "Resources");

builder.Services.Configure<RequestLocalizationOptions>(o =>
{
    List<CultureInfo> cultureInfos = new List<CultureInfo>()
    {
        new CultureInfo("en-US"),
        new CultureInfo("fr-BE")
    };

    o.SetDefaultCulture("en-US");
    o.SupportedCultures = cultureInfos;
    o.SupportedUICultures = cultureInfos;
});

//await builder.Build().RunAsync();

WebAssemblyHost host = builder.Build();

CultureInfo cultureInfo;
IJSRuntime js = host.Services.GetRequiredService<IJSRuntime>();

string currentCulture = await js.InvokeAsync<string>("localStorage.getItem", "blazorCulture");

if(currentCulture is not null)
{
    cultureInfo = new CultureInfo(currentCulture);
}
else
{
    cultureInfo= new CultureInfo("en-US");
    await js.InvokeVoidAsync("localStorage.setItem", "blazorCulture", cultureInfo.Name);
}

CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

await host.RunAsync();