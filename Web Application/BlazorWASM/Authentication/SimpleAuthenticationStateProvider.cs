using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;

namespace BlazorWASM.Authentication;

public class SimpleAuthenticationStateProvider : AuthenticationStateProvider  
    /*-- AuthenticationStateProvider -- Dette er en abstrakt klasse, der findes i Blazor-rammen. Det bruges til at give oplysninger om hvem der er logget ind, og hvilke privilegier de har*/
{
    private readonly IAuthManager authManager;

    public SimpleAuthenticationStateProvider(IAuthManager authManager)
    {
        this.authManager = authManager;
        authManager.OnAuthStateChanged += AuthStateChanged;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        ClaimsPrincipal principal = await authManager.GetAuthAsync();
        return await Task.FromResult(new AuthenticationState(principal));
    }

    private void AuthStateChanged(ClaimsPrincipal principal)
    {
        NotifyAuthenticationStateChanged(
            Task.FromResult(
                new AuthenticationState(principal)
            )
        );
    }
}