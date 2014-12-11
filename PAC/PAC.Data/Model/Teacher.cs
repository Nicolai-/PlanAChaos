using System.Collections.Generic;

namespace PAC.Data.Model
{
    /// <summary>
    /// The teacher.
    /// </summary>
    public class Teacher
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets the teacher courses.
        /// </summary>
        public virtual IList<TeacherCourse> TeacherCourses { get; private set; }
    }
}
