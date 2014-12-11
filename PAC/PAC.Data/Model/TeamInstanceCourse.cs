// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TeamInstanceCourse.cs" company="J.N Systems">
//   .
// </copyright>
// <summary>
//   Defines the TeamInstanceCourse type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace PAC.Data.Model
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// The team instance course.
    /// </summary>
    public class TeamInstanceCourse
    {
        /// <summary>
        /// Gets or sets the course id.
        /// </summary>
        [Key, Column(Order = 0)]
        public int CourseId { get; set; }

        /// <summary>
        /// Gets or sets the team instance id.
        /// </summary>
        [Key, Column(Order = 1)]
        public int TeamInstanceId { get; set; }

        /// <summary>
        /// Gets or sets the week.
        /// </summary>
        public int Week { get; set; }

        /// <summary>
        /// Gets or sets the teacher id.
        /// </summary>
        public int TeacherId { get; set; }

        /// <summary>
        /// Gets the team instance.
        /// Relation to TeamInstance
        /// </summary>
        public virtual TeamInstance TeamInstance { get; private set; }

        /// <summary>
        /// Gets the course.
        /// Relation to Course
        /// </summary>
        public virtual Course Course { get; private set; }
    }
}