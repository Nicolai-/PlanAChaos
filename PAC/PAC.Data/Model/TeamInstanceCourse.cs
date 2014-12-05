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
        public int CourseId { get; set; }
        public int TeamInstanceId { get; set; }

        public int Week { get; set; }
        public int TeacherId { get; set; }

        //Relation to TeamInstance
        public virtual TeamInstance TeamInstance { get; set; } 

        //Relation to Course
        public virtual Course Course { get; set; }
    }
}
