namespace WebApp
{
    using System.IdentityModel.Tokens.Jwt;

    using Microsoft.AspNetCore.Authentication.Cookies;
    using Microsoft.AspNetCore.Authentication.OpenIdConnect;
    using Microsoft.AspNetCore.Authentication;

    using Microsoft.Net.Http.Headers;

    using Common.Policy;

    using Queries;
    using ReadOnlyStorage;

    using Services;
    using Storage;

    public static class StartupExtensions
    {
        public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
        {
            // Queries services
            builder.Services.AddAplicationQueryServices();
            builder.Services.AddReadOnlyStorageServices(builder.Configuration);

            // Service layer services
            builder.Services.AddAplicationServices(builder.Configuration);
            builder.Services.AddStorageServices(builder.Configuration);

            // add MVC
            builder.Services.AddControllersWithViews();

            // Authentication and authorization
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

            builder.Services.AddAccessTokenManagement();

            builder.Services.AddHttpClient("APIClient", client =>
            {
                client.BaseAddress = new Uri(builder.Configuration["webapiRoot"]);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
            }).AddUserAccessTokenHandler();

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
            })
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
                {
                    options.AccessDeniedPath = "/Authentication/AccessDenied";
                })
                .AddOpenIdConnect(OpenIdConnectDefaults.AuthenticationScheme, options =>
                {
                    options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    options.Authority = "https://localhost:5001";
                    options.ClientId = "webApp";
                    options.ClientSecret = "8292rnqw9#$%^&^@hwefwe192784y124bqfuignwegui";
                    options.ResponseType = "code";
                    // default path -- might change in the future!
                    //options.CallbackPath = new PathString("signin-oidc");
                    options.SaveTokens = true;
                    options.GetClaimsFromUserInfoEndpoint = true;
                    options.ClaimActions.Remove("aud");
                    options.ClaimActions.DeleteClaim("sid");
                    options.ClaimActions.DeleteClaim("idp");
                    options.Scope.Add("roles");
                    options.Scope.Add("country");
                    options.Scope.Add("offline_access");
                    options.Scope.Add("webapi.readAccess");
                    options.ClaimActions.MapJsonKey("role", "role");
                    options.ClaimActions.MapJsonKey("country", "country");
                    options.ClaimActions.MapJsonKey("offline_access", "offline_access");

                    options.TokenValidationParameters = new()
                    {
                        NameClaimType = "given_name",
                        RoleClaimType = "role",
                    };
                });

            // Add authorization policies (for the moment this can be commented out!)
            builder.Services.AddAuthorization(authorizationPolicies =>
            {
                authorizationPolicies.AddPolicy("CanViewEmployeess", AuthorizationPolicies.CanViewEmployees());
            });


            return builder.Build();
        }

        public static WebApplication ConfigurePipeline(this WebApplication app)
        {
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. This should change in production scenarios https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            return app;
        }
    }
}
