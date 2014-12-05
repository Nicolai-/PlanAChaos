using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAC.Data.Model
{
    public class TeamInstance
    {
        public int Id { get; set; }
        public string TeamInstanceName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        //Relation to Student
        public virtual IList<Student> Students { get; set; }
        //Relation to TeamInstanceCourse
        public virtual IList<TeamInstanceCourse> TeamInstanceCourses { get; set; }

        //Relation to Team
        public int? TeamId { get; set; }
        public virtual Team Team { get; set; }
    }
}
