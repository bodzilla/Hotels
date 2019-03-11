using System;

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

        /// <summary>
        /// The date/time when the entity was created.
        /// </summary>
        DateTime EntityCreated { get; set; }

        /// <summary>
        /// The entity active state.
        /// </summary>
        bool EntityActive { get; set; }
    }
}
