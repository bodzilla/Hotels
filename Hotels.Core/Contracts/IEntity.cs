namespace Hotels.Core.Contracts
{
    /// <summary>
    /// The base interface for all models.
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// The id of the entity.
        /// </summary>
        int Id { get; set; }
    }
}
