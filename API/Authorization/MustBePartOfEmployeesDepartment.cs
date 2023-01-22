namespace WEBAPI.Authorization
{
    using Microsoft.AspNetCore.Authorization;
    using System.Threading.Tasks;

    public class MustBePartOfEmployeesDepartmentRequirement : IAuthorizationRequirement
    {
        public MustBePartOfEmployeesDepartmentRequirement()
        { }
    }

    public class MustBePartOfEmployeesDepartmentHandler 
        : AuthorizationHandler<MustBePartOfEmployeesDepartmentRequirement>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public MustBePartOfEmployeesDepartmentHandler(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor ??
                throw new ArgumentNullException(nameof(httpContextAccessor));
        }

        protected async override Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            MustBePartOfEmployeesDepartmentRequirement requirement)
        {
            // take the value from somewhere and do something 

            string? employeesDepartment = _httpContextAccessor.HttpContext?
                .GetRouteValue("departmentId")?.ToString();

            if (employeesDepartment == null)
            {
                context.Fail();
                return;
            }

            //additional chacks here and if no check fails, then context is succeded.
            // ....

            context.Succeed(requirement);
        }
    }
}
