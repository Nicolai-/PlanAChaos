
using System.Collections;
using System.Collections.Generic;

namespace PAC.Data.Model
{
    public class Course
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public int CourseLength { get; set; }
        public string CourseDesription { get; set; }

        //Relation to TeamInstanceCourse
        public virtual IList<TeamInstanceCourse> TeamInstanceCourses { get; set; }
    }
}
