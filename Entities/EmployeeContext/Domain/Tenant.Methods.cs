namespace Entities.EmployeeContext.Domain
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
        /// <returns></returns>
        public static Result<Tenant> CreateFromStorage(
            int id,
            Guid uid,
            DateTime createdOn,
            DateTime? deletedOn)
        {
            Tenant tenant = new()
            {
                Id = id,
                Uid = uid,
                CreatedOn = createdOn,
                DeletedOn = deletedOn,
            };

            return Result<Tenant>.OK(tenant);
        }
    }
}
