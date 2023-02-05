namespace Contracts.Common.DomainEntities
{
    public abstract partial class DomainEntity
    {
        /// <summary>
        /// Mark the entiity as modified
        /// </summary>
        public void MarkAsModified()
        {
            Modified = true;
        }
    }

}
