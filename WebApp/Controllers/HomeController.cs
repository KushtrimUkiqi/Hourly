﻿namespace WebApp.Controllers
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
    using Contracts.Common.Constants;
    using Contracts.Common.ResultTexts;
    using Queries.Employee.GetEmployeeQuery;
    using WebApp.Models.Home;
    using Services.Employee.Commands.DeleteEmployeeCommand;
    using Services.Employee.Commands.EmployeeInvitedCommand;

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
            //var userId = User.Claims.FirstOrDefault(x => x.Type == "sub")?.Value;

            if(!Guid.TryParse(User.Claims.FirstOrDefault(x => x.Type == UserClaims.TenantUid)?.Value,out Guid tenantUid))
            {
                return View(new TableViewModel
                {
                    Error = ResultTexts.TENANT_NOT_FOUND
                }); ;
            }

            //await LogIdentityInformation();

            var employeesResult = await _mediator.Send(new GetEmployeesQuery(tenantUid: tenantUid, pageNumber: 0, pageSize: 100));

            if(employeesResult.IsFailure)
            {
                return View(new TableViewModel
                {
                    Error = employeesResult.ErrorMessage
                });
            }

            return View(new TableViewModel
            {
                Value = employeesResult.Value
            });
        }

        /// <summary>
        /// Http get operation
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Http post operation
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstName,LastName,Email,PhoneNumber,Position")] CreateEmployeeRequest request)
        {
            if (!Guid.TryParse(User.Claims.FirstOrDefault(x => x.Type == UserClaims.TenantUid)?.Value, out Guid tenantUid))
            {
                return View(new EmployeeDetailsModel
                {
                    Error = ResultTexts.TENANT_NOT_FOUND
                }); ;
            }

            Result<Guid> createdEmployeeUidResult = await _mediator.Send(new CreateEmployeeCommand(tenantUid: tenantUid,request: request));

            if (createdEmployeeUidResult.IsFailure)
            {
                return View("Details", new EmployeeDetailsModel
                {
                    Error = createdEmployeeUidResult.ErrorMessage
                });
            }

            var employeeResult = await _mediator.Send(new GetEmployeeQuery(tenantUid: tenantUid, employeeUid: createdEmployeeUidResult.Value));


            if (employeeResult.IsFailure)
            {
                return View("Details", new EmployeeDetailsModel
                {
                    Error = employeeResult.ErrorMessage
                });
            }

            return View("Details", new EmployeeDetailsModel
            {
                Value = employeeResult.Value
            });
        }

        /// <summary>
        /// Http get operation
        /// </summary>
        /// <param name="employeeUid"></param>
        /// <returns></returns>
        public async Task<IActionResult> Details(Guid employeeUid)
        {
            if (!Guid.TryParse(User.Claims.FirstOrDefault(x => x.Type == UserClaims.TenantUid)?.Value, out Guid tenantUid))
            {
                return View(new TableViewModel
                {
                    Error = ResultTexts.TENANT_NOT_FOUND
                });
            }

            var employeeResult = await _mediator.Send(new GetEmployeeQuery(tenantUid: tenantUid, employeeUid: employeeUid));

            if(employeeResult.IsFailure)
            {
                return View(new EmployeeDetailsModel
                {
                    Error = employeeResult.ErrorMessage
                });
            }

            return View(new EmployeeDetailsModel
            {
                Value = employeeResult.Value,
            });
        }

        /// <summary>
        /// Http deleted operation
        /// </summary>
        /// <param name="employeeUid"></param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(Guid employeeUid)
        {
            if (!Guid.TryParse(User.Claims.FirstOrDefault(x => x.Type == UserClaims.TenantUid)?.Value, out Guid tenantUid))
            {
                return View("Index", new TableViewModel
                {
                    Error = ResultTexts.TENANT_NOT_FOUND
                });
            }

            var employeeDeletedResult = await _mediator.Send(new DeleteEmployeeCommand(tenantUid: tenantUid, employeeUid: employeeUid));

            if (employeeDeletedResult.IsFailure)
            {
                return View("Index", new EmployeeDetailsModel
                {
                    Error = employeeDeletedResult.ErrorMessage
                });
            }

            var employeesResult = await _mediator.Send(new GetEmployeesQuery(tenantUid: tenantUid, pageNumber: 0, pageSize: 100));

            if (employeesResult.IsFailure)
            {
                return View("Index", new TableViewModel
                {
                    Error = employeesResult.ErrorMessage
                });
            }

            return View("Index", new TableViewModel
            {
                Value = employeesResult.Value
            });
        }

        public async Task<IActionResult> Invite(Guid employeeUid, bool fromTableView = true)
        {
            var view = fromTableView ? "Index" : "Details";

            if (!Guid.TryParse(User.Claims.FirstOrDefault(x => x.Type == UserClaims.TenantUid)?.Value, out Guid tenantUid))
            {
                return View(view, new GeneralModel<string>
                {
                    Error = ResultTexts.TENANT_NOT_FOUND
                });
            }

            var employeeInvitedResult = await _mediator.Send(new InviteEmployeeCommand(tenantUid: tenantUid, employeeUid: employeeUid));

            if (employeeInvitedResult.IsFailure)
            {
                return View(view, new GeneralModel<string>
                {
                    Error = employeeInvitedResult.ErrorMessage
                });
            }


            if (fromTableView)
            {
                var employeesResult = await _mediator.Send(new GetEmployeesQuery(tenantUid: tenantUid, pageNumber: 0, pageSize: 100));

                if (employeesResult.IsFailure)
                {
                    return View(view, new TableViewModel
                    {
                        Error = employeesResult.ErrorMessage
                    });
                }

                return View(view, new TableViewModel
                {
                    Value = employeesResult.Value
                });
            }
            else
            {
                var employeeResult = await _mediator.Send(new GetEmployeeQuery(tenantUid: tenantUid, employeeUid: employeeUid));

                if (employeeResult.IsFailure)
                {
                    return View(view, new EmployeeDetailsModel
                    {
                        Error = employeeResult.ErrorMessage
                    });
                }

                return View(view, new EmployeeDetailsModel
                {
                    Value = employeeResult.Value,
                });
            }

        }

        /// <summary>
        /// Http get operation
        /// </summary>
        /// <returns></returns>
        public IActionResult Privacy()
        {
            return View();
        }
        /// <summary>
        /// Http get operation
        /// </summary>
        /// <returns></returns>
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