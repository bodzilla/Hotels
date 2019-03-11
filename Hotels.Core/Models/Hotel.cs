using System;
using Hotels.Core.Contracts;
using Hotels.Core.Enums;

namespace Hotels.Core.Models
{
    /// <inheritdoc />
    /// <summary>
    /// The hotel class.
    /// </summary>
    public sealed class Hotel : IEntity
    {
        /// <inheritdoc />
        public int Id { get; set; }

        /// <inheritdoc />
        public DateTime EntityCreated { get; set; }

        /// <inheritdoc />
        public bool EntityActive { get; set; }

        /// <summary>
        /// The hotel name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The description of the hotel.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The location of the hotel.
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// The hotel rating.
        /// </summary>
        public Rating Rating { get; set; }
    }
}
