// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Team.cs" company="J.N Systems">
//   .
// </copyright>
// <summary>
//   The team.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace PAC.Data.Model
{
    using System.Collections.Generic;

    /// <summary>
    /// The team.
    /// </summary>
    public class Team
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the number of weeks.
        /// </summary>
        public int NumberOfWeeks { get; set; }

        /// <summary>
        /// Gets or sets the team name.
        /// </summary>
        public string TeamName { get; set; }

        /// <summary>
        /// Gets the team instances.
        /// Relation to TeamInstance
        /// Navigation property to TeamInstance
        /// </summary>
        public virtual IList<TeamInstance> TeamInstances { get; private set; }
    }
}
