namespace Entities.TenantContext.Domain
{
    using Contracts.Common.Results;

    public partial class Tenant
    {
        /// <summary>
        /// Creates domain entity from storage
        /// </summary>
        /// <param name="id"></param>
        /// <param name="uid"></param>
        /// <param name="createdOn"></param>
        /// <param name="deletedOn"></param>
        /// <param name="name"></param>
        /// <param name="address"></param>
        /// <param name="website"></param>
        /// <param name="employees"></param>
        /// <returns></returns>
        public static Result<Tenant> CreateFromStorage(
            int id,
            Guid uid,
            DateTime createdOn,
            DateTime? deletedOn,
            string? name,
            string? address,
            string? website,
            IEnumerable<Employee> employees)
        {
            Tenant tenant = new()
            {
                Id = id,
                Uid = uid,
                CreatedOn = createdOn,
                DeletedOn = deletedOn,
                Name = name,
                Address = address,
                WebSite = website
            };

            tenant._employees.AddRange(employees);

            return Result<Tenant>.OK(tenant);
        }
    }
}
