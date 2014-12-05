using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAC.Data.Model
{
    public class TeacherCourse
    {
        public int TeacherId { get; set; }
        public int CourseId { get; set; }


        //Relation to Teacher
        public virtual Teacher Teacher { get; set; }
        //Relation to Course
        public virtual Course Course { get; set; }
    }
}
