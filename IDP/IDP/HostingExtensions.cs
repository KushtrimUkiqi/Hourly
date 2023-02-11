namespace IDP;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using Duende.IdentityServer;

using IDP.Services;
using IDP.DbContexts;

using Serilog;

public static class HostingExtensions
{
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        // uncomment if you want to add a UI
        builder.Services.AddRazorPages();
        builder.Services.AddScoped<IPasswordHasher<Entities.User>, PasswordHasher<Entities.User>>();
        builder.Services.AddScoped<ILocalUserService, LocalUserService>();

        builder.Services.AddDbContext<IdentityDbContext>(options =>
        {
            options.UseSqlite(
                builder.Configuration
                .GetConnectionString("IdentityDBConnectionString"));
        });

        builder.Services.AddAuthentication()
            .AddFacebook("Facebook", options =>
            {
                options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;
                options.AppId = "5694100410681028";
                options.AppSecret = "6cba711b0e76d2deede52caf01cd6e05";
            });

        builder.Services.AddIdentityServer(options =>
            {
                // https://docs.duendesoftware.com/identityserver/v6/fundamentals/resources/api_scopes#authorization-based-on-scopes
                options.EmitStaticAudienceClaim = true;
            })
            .AddProfileService<LocalUserProfileService>()
            .AddInMemoryIdentityResources(Config.IdentityResources)
            .AddInMemoryApiScopes(Config.ApiScopes)
            .AddInMemoryApiResources(Config.ApiResources)
            .AddInMemoryClients(Config.Clients);

        return builder.Build();
    }
    
    public static WebApplication ConfigurePipeline(this WebApplication app)
    { 
        app.UseSerilogRequestLogging();
    
        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        // uncomment if you want to add a UI
        app.UseStaticFiles();
        app.UseRouting();

        app.UseIdentityServer();

        app.UseAuthorization();

        app.MapRazorPages()
            .RequireAuthorization();

        return app;
    }
}
