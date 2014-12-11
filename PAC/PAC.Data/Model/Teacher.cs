using System.Collections.Generic;

namespace PAC.Data.Model
{
    public class Teacher
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual IList<TeacherCourse> TeacherCourses { get; set; }
    }
}
