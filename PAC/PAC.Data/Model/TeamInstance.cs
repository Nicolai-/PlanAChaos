// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TeamInstance.cs" company="J.N Systems">
//   .
// </copyright>
// <summary>
//   Defines the TeamInstance type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace PAC.Data.Model
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The team instance.
    /// </summary>
    public class TeamInstance
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the team instance name.
        /// </summary>
        public string TeamInstanceName { get; set; }

        /// <summary>
        /// Gets or sets the start date.
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Gets or sets the end date.
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Gets the students.
        /// Relation to Student
        /// </summary>
        public virtual IList<Student> Students { get; private set; }
        
        /// <summary>
        /// Gets the team instance courses.
        /// Relation to TeamInstanceCourse
        /// </summary>
        public virtual IList<TeamInstanceCourse> TeamInstanceCourses { get; private set; }

        /// <summary>
        /// Gets or sets the team id. Nullable integer
        /// Relation to Team
        /// </summary>
        public int? TeamId { get; set; }

        /// <summary>
        /// Gets the team.
        /// </summary>
        public virtual Team Team { get; private set; }
    }
}
