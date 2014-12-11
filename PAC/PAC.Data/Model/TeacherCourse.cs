
namespace PAC.Data.Model
{
    /// <summary>
    /// The teacher course class.
    /// </summary>
    public class TeacherCourse
    {
        /// <summary>
        /// Gets or sets the teacher id.
        /// </summary>
        public int TeacherId { get; set; }

        /// <summary>
        /// Gets or sets the course id.
        /// </summary>
        public int CourseId { get; set; }

        /// <summary>
        /// Gets or sets the teacher
        /// Relation to Teacher.
        /// </summary>
        public virtual Teacher Teacher { get; set; }

        /// <summary>
        /// Gets or sets the course.
        /// Relation to Courses
        /// </summary>
        public virtual Course Course { get; set; }
    }
}
