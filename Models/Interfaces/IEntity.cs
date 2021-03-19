using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Interfaces
{
    public interface IEntity<TId>
    {
        public TId Id { get; set; }
        /// <summary>
        /// Gets or sets the created date.
        /// </summary>
        /// <value>The created date.</value>
        public DateTime CreatedDate { get; set; }
        /// <summary>
        /// Gets or sets the IsDeleted.
        /// </summary>
        /// <value>The modifier IsDeleted.</value>
        public bool IsDeleted { get; set; }
    }
}
