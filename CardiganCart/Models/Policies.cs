using Microsoft.AspNetCore.Authorization;

namespace CardiganCart.Models
{
    public static class Policies
    {
        public static AuthorizationPolicy AdminPolicy()
        {
            return new AuthorizationPolicyBuilder().RequireAuthenticatedUser()
            .RequireRole(UserRoles.Admin).Build();
        }
        public static AuthorizationPolicy UserPolicy()
        {
            return new AuthorizationPolicyBuilder().RequireAuthenticatedUser()
            .RequireRole(UserRoles.User).Build();
        }
    }
}
