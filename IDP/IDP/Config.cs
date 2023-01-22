namespace IDP;

using Duende.IdentityServer;
using Duende.IdentityServer.Models;

public static class Config
{
    public static IEnumerable<IdentityResource> IdentityResources =>
        new IdentityResource[]
        { 
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResource("roles", "Your roles", new [] { "role" }),
            new IdentityResource("country", "Your country", new [] { "country" })

        };

    public static IEnumerable<ApiResource> ApiResources =>
    new ApiResource[]
        { 
            new ApiResource("webapi","WEB API",
                new [] { "role", "country" })
            {
                Scopes = { "webapi.fullaccess" }
            }
        };

    public static IEnumerable<ApiScope> ApiScopes =>
        new ApiScope[] 
            {
                new ApiScope("webapi.readAccess", "webapi.writeAccess")
            };

    public static IEnumerable<Client> Clients =>
        new Client[] 
            { 
                new Client()
                {
                    ClientName = "WEB APP",
                    ClientId = "webApp",
                    AllowedGrantTypes = GrantTypes.Code,
                    AllowOfflineAccess = true,
                    //IdentityTokenLifetime = 
                    //AuthorizationCodeLifetime = ...
                    //AccessTokenLifetime = 3600, default,
                    UpdateAccessTokenClaimsOnRefresh = true,
                    RedirectUris =
                    {
                        "https://localhost:7107/signin-oidc"
                    },
                    PostLogoutRedirectUris =
                    {
                        "https://localhost:7107/signout-callback-oidc"
                    },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "roles",
                        "webapi.readAccess",
                        "country"
                    },
                    ClientSecrets = 
                    {
                        new Secret("8292rnqw9#$%^&^@hwefwe192784y124bqfuignwegui".Sha256())
                    },
 

                }
            };
}