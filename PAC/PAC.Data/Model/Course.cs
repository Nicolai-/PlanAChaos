
namespace PAC.Data.Model
{
    using System.Collections.Generic;

    /// <summary>
    /// The course.
    /// </summary>
    public class Course
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the course name.
        /// </summary>
        public string CourseName { get; set; }

        /// <summary>
        /// Gets or sets the course length.
        /// </summary>
        public int CourseLength { get; set; }

        /// <summary>
        /// Gets or sets the course description.
        /// </summary>
        public string CourseDescription { get; set; }

        /// <summary>
        /// Gets the team instance courses.
        /// Navigation property to TeamInstanceCourse
        /// </summary>
        public virtual IList<TeamInstanceCourse> TeamInstanceCourses { get; private set; }

        /// <summary>
        /// Gets the teacher courses.
        /// Navigation property to TeacherCourse
        /// </summary>
        public virtual IList<TeacherCourse> TeacherCourses { get; private set; }
    }
}
