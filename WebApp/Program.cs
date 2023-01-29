using Common.Policy;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.Net.Http.Headers;
using System.IdentityModel.Tokens.Jwt;
using WebApp;

var builder = WebApplication.CreateBuilder(args);

var app = builder
    .ConfigureServices()
    .ConfigurePipeline();

app.Run();

// Add services to the container.
//builder.Services.AddControllersWithViews();

//JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

//builder.Services.AddAccessTokenManagement();

//builder.Services.AddHttpClient("APIClient", client =>
//{
//    client.BaseAddress = new Uri(builder.Configuration["webapiRoot"]);
//    client.DefaultRequestHeaders.Clear();
//    client.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
//}).AddUserAccessTokenHandler();

//builder.Services.AddAuthentication(options =>
//{
//    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
//    options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
//}).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,  options =>
//{
//    options.AccessDeniedPath = "/Authentication/AccessDenied";
//})
//.AddOpenIdConnect(OpenIdConnectDefaults.AuthenticationScheme, options =>
//{
//    options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
//    options.Authority = "https://localhost:5001";
//    options.ClientId = "webApp";
//    options.ClientSecret = "8292rnqw9#$%^&^@hwefwe192784y124bqfuignwegui";
//    options.ResponseType = "code";
//    //options.CallbackPath = new PathString("signin-oidc");
//    options.SaveTokens = true;
//    options.GetClaimsFromUserInfoEndpoint = true;
//    options.ClaimActions.Remove("aud");
//    options.ClaimActions.DeleteClaim("sid");
//    options.ClaimActions.DeleteClaim("idp");
//    options.Scope.Add("roles");
//    options.Scope.Add("country");
//    options.Scope.Add("offline_access");
//    options.Scope.Add("webapi.readAccess");
//    options.ClaimActions.MapJsonKey("role", "role");
//    options.ClaimActions.MapJsonKey("country", "country");
//    options.ClaimActions.MapJsonKey("offline_access", "offline_access");

//    options.TokenValidationParameters = new()
//    {
//        NameClaimType = "given_name",
//        RoleClaimType = "role",
//    };
//});

//builder.Services.AddAuthorization(authorizationPolicies =>
//{
//    authorizationPolicies.AddPolicy("CanViewEmployeess", AuthorizationPolicies.CanViewEmployees());
//});


//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Home/Error");
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}

//app.UseHttpsRedirection();
//app.UseStaticFiles();

//app.UseRouting();

//app.UseAuthentication();
//app.UseAuthorization();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");

//app.Run();
