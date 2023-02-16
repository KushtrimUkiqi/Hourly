namespace Queries.Tenant.GetTenantQuery
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using Contracts.Common.Results;
    using Contracts.Tenant.Responses;
    using Queries.Tenant.Repository;

    using MediatR;

    public class GetTenantQuery : IRequest<Result<TenantResponseDto>>
    {
        public Guid TenantUid { get; set; }

        public GetTenantQuery(Guid tenantUid)
        {
            TenantUid = tenantUid;
        }
    }

    public class GetTenantQueryHandler : IRequestHandler<GetTenantQuery, Result<TenantResponseDto>>
    {
        private readonly ITenantReadOnlyRepository _tenantReadOnlyRepository;

        public GetTenantQueryHandler(ITenantReadOnlyRepository tenantReadOnlyRepository)
        {
            _tenantReadOnlyRepository = tenantReadOnlyRepository;
        }

        public async Task<Result<TenantResponseDto>> Handle(GetTenantQuery request, CancellationToken cancellationToken)
        {
            var tenantResult = await _tenantReadOnlyRepository.GetTenantByUidAsync(request.TenantUid);

            if(tenantResult.IsFailure)
            {
                return Result<TenantResponseDto>.FROM_ERROR(tenantResult);
            }

            return Result<TenantResponseDto>.OK(
                new TenantResponseDto()
                {
                    Name = tenantResult.Value.Name ?? string.Empty,
                    WebSite = tenantResult.Value.WebSite ?? string.Empty,
                    Address = tenantResult.Value.Address ?? string.Empty,
                });
        }
    }
}
