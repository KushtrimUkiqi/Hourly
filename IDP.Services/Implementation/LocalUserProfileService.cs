namespace IDP.Services
{
    using System.Security.Claims;

    using IDP.Services.Interfaces;
    using IDP.Common.Contracts.IUnitOfWork;

    using Duende.IdentityServer.Models;
    using Duende.IdentityServer.Extensions;

    public class LocalUserProfileService : ILocalUserProfileService
    {
        private readonly ILocalUserService _localUserService;
        private readonly IUnitOfWork _unitOfWork;

        public LocalUserProfileService(ILocalUserService localUserService, IUnitOfWork unitOfWork)
        {
            _localUserService = localUserService;
            _unitOfWork = unitOfWork;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var subjectId = context.Subject.GetSubjectId();
            var claimsForUser = (await _localUserService
                .GetUserClaimsBySubjectAsync(subjectId))
                .ToList();

            context.AddRequestedClaims(
                claimsForUser.Select(c => new Claim(c.Type, c.Value)).ToList());

        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            context.IsActive = true;
            //var subjectId = context.Subject.GetSubjectId();
            //context.IsActive = await _localUserService
            //    .IsUserActive(subjectId);
        }
    }
}
