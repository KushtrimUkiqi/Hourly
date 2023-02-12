namespace WebApp.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using Microsoft.AspNetCore.Authorization;
    using Queries.Employee.GetEmployeesQuery;

    using WebApp.Models;
    using MediatR;
    using Queries.Tenant.GetTenantQuery;

    [Authorize]
    public class TenantController : Controller
    {
        private readonly IMediator _mediator;

        public TenantController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var userId = User.Claims.FirstOrDefault(x => x.Type == "sub")?.Value;

            var tenantResult = await _mediator.Send(new GetTenantQuery(tenantUid: Guid.Parse("5fe154f4-ecd4-40e6-8ef7-5c29d626e53d")));

            if (tenantResult.IsFailure)
            {
                return View(new TenantIndexModel
                {
                    Error = tenantResult.ErrorMessage
                });
            }

            return View(new TenantIndexModel
            {
                Address = tenantResult.Value.Address,
                WebSite = tenantResult.Value.WebSite,
                Name = tenantResult.Value.Name
            });
        }
    }
}
