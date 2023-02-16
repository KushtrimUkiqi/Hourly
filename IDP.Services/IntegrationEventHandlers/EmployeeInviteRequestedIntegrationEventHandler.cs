namespace IDP.Services.IntegrationEventHandlers
{
    using CommonProject.IntegrationEvents;
    using IdentityModel;
    using IDP.Domain.Entities;
    //using Contracts.Employee.IntegrationEvents;
    using IDP.Domain.IntegrationEvents;
    //using Contracts.Employee.IntegrationEvents;
    using IDP.Domain.IntegrationEvents;
    using IDP.Services.Interfaces;
    using MassTransit;
    using System;
    using System.Threading.Tasks;

    public sealed class EmployeeInviteRequestedIntegrationEventHandler : IConsumer<EmployeeInviteRequestedIntegrationEvent>
    {
        private readonly ILocalUserService _localUserService;

        public EmployeeInviteRequestedIntegrationEventHandler(ILocalUserService localUserService)
        {
            _localUserService = localUserService;
        }

        public async Task Consume(ConsumeContext<EmployeeInviteRequestedIntegrationEvent> context)
        {
            // create user & claims
            var userToCreate = new User
            {
                CreatedOn = DateTime.UtcNow,
                UserName = context.Message.Email,
                Subject = Guid.NewGuid().ToString(),
                Email = context.Message.Email,
                Active = false
            };
            //userToCreate.Claims.Add(new UserClaim()
            //{
            //    CreatedOn = DateTime.UtcNow,
            //    Type = "country",
            //    Value = Input.Country
            //});

            userToCreate.Claims.Add(new UserClaim()
            {
                CreatedOn = DateTime.UtcNow,
                Type = JwtClaimTypes.GivenName,
                Value = context.Message.Name
            });

            userToCreate.Claims.Add(new UserClaim()
            {
                CreatedOn = DateTime.UtcNow,
                Type = JwtClaimTypes.FamilyName,
                Value = context.Message.Name
            });

            await _localUserService.AddNewUser(userToCreate);
            //await _localUserService.SaveChangesAsync();

            // create an activation link - we need an absolute URL, therefore
            // we use Url.PageLink instead of Url.Page for local testing
            var activationLink = $"/user/activation/index/{userToCreate.SecurityCode}";

            Console.WriteLine(activationLink);
        }
    }
}
