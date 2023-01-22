namespace Common.Policy
{
    using Microsoft.AspNetCore.Authorization;

    public static class AuthorizationPolicies
    {
        public static AuthorizationPolicy CanViewEmployees()
        {
            return new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                    .RequireClaim("country", "Albania")
                    .RequireRole("Admin")
                    .Build();
        }
    }
}
