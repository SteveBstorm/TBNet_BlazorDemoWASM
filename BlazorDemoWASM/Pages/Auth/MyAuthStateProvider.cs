using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BlazorDemoWASM.Pages.Auth
{
    //Microsoft.AspNetCore.Components.Authorization
    public class MyAuthStateProvider(IJSRuntime js) : AuthenticationStateProvider
    {
        string token;
        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            token = await js.InvokeAsync<string>("localStorage.getItem", "token");
            if(!string.IsNullOrEmpty(token))
            {
                JwtSecurityToken jwt = new JwtSecurityToken(token);
                ClaimsIdentity currentUser = new ClaimsIdentity(jwt.Claims, "JwtAuth");
                //jwt.Claims.First(x => x.Type == ClaimTypes.Role);

                return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(currentUser)));
            }

            ClaimsIdentity anonymous = new ClaimsIdentity();
            return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(anonymous)));
        }

        //Mettre à jour l'utilisateur courant
        public void NotifyUserChanged()
        {
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }
    }
}
