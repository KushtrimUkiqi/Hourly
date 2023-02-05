namespace WebApp.Controllers
{
    using System.Text;
    using System.Diagnostics;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.IdentityModel.Protocols.OpenIdConnect;

    using WebApp.Models;

    using Contracts.Common.Results;
    using Contracts.Employee.Requests;

    using Queries.Employee.GetEmployeesQuery;

    using Services.Employee.Commands.CreateEmployeeCommand;

    using MediatR;


    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMediator _mediator;

        public HomeController(ILogger<HomeController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var userId = User.Claims.FirstOrDefault(x => x.Type == "sub")?.Value;

            await LogIdentityInformation();

            var employeesResult = await _mediator.Send(new GetEmployeesQuery(pageNumber: 0, pageSize: 100));

            if(employeesResult.IsFailure)
            {
                return View(new IndexModel
                {
                    Error = employeesResult.ErrorMessage
                });
            }

            return View(new IndexModel
            {
                Employees = employeesResult.Value
            });
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstName,LastName,Email,PhoneNumber,Position")] CreateEmployeeRequest request)
        {
            Result<Guid> createdEmployeeUidResult = await _mediator.Send(new CreateEmployeeCommand(request: request));

            ///remake this part
            if (createdEmployeeUidResult.IsFailure)
            {
                Error();
            }

            return View("Details", request);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task LogIdentityInformation()
        {
            var identityToken = await HttpContext
                .GetTokenAsync(OpenIdConnectParameterNames.IdToken);

            var accessToken = await HttpContext
                .GetTokenAsync(OpenIdConnectParameterNames.AccessToken);

            var userClaimsStringBuilder = new StringBuilder();

            foreach (var claim in User.Claims)
            {
                userClaimsStringBuilder.AppendLine(
                    $"Claim type: {claim.Type} = Claim value: {claim.Value}");
            }

            _logger.LogInformation($"Identity token & user claims: " +
                $"\n{identityToken} " +
                $"accesstoken: \n{accessToken} \n{userClaimsStringBuilder}");
        }
    }
}