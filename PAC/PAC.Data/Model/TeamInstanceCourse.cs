using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAC.Data.Model
{
    public class TeamInstanceCourse
    {
        [Key]
        public int CourseId { get; set; }
        public int TeamInstanceId { get; set; }

        public int Week { get; set; }
        public int TeacherId { get; set; }

        //Relation to TeamInstance
        public virtual IList<TeamInstance> TeamInstances { get; set; } 

        //Relation to Course
        public virtual IList<Course> Courses { get; set; }
    }
}
