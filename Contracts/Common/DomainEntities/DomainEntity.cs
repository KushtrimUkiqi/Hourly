namespace Contracts.Common.DomainEntities
{
    public abstract partial class DomainEntity
    {
        /// <summary>
        /// Entity id
        /// </summary>
        public int Id { get; protected set; }

        /// <summary>
        /// Date and time when the entity has been created on
        /// </summary>
        public DateTime CreatedOn { get; protected set; }

        /// <summary>
        /// Date and time when the entity has been deleted on
        /// </summary>
        public DateTime? DeletedOn { get; protected set; }

        /// <summary>
        /// Tells if the entity has been modified
        /// </summary>
        public bool Modified { get; private set; }

        /// <summary>
        /// Tells if the entity has been deleted
        /// </summary>
        public bool Deleted => DeletedOn != null;
    }
}
