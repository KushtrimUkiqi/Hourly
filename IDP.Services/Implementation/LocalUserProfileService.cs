namespace IDP.Services
{
    using System.Security.Claims;

    using IDP.Services.Interfaces;
    using IDP.Common.Contracts.IUnitOfWork;

    using Duende.IdentityServer.Models;
    using Duende.IdentityServer.Extensions;
    using IDP.Common.Constants;

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

            Domain.Entities.User user = await _localUserService.GetUserBySubjectAsync(subjectId);

            var claimsForUser = (await _localUserService
                .GetUserClaimsBySubjectAsync(subjectId))
                .ToList();

            var userPermissions = user.UserRoles.SelectMany(x => x.Role.Permissions).Distinct().ToList();

            var userClaims = claimsForUser.Select(c => new Claim(c.Type, c.Value)).ToList();

            userClaims.Add(new Claim(UserClaims.TenantUid, user.TenantUid.ToString()));

            userClaims.AddRange(userPermissions.Select(x => new Claim(UserClaims.Permissions, x.Name)));

            context.AddRequestedClaims(userClaims);

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
