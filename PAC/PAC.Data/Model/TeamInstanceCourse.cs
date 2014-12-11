using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PAC.Data.Model
{
    public class TeamInstanceCourse
    {
        [Key, Column(Order = 0)]
        public int CourseId { get; set; }
        [Key, Column(Order = 1)]
        public int TeamInstanceId { get; set; }

        public int Week { get; set; }
        public int TeacherId { get; set; }

        //Relation to TeamInstance
        public virtual TeamInstance TeamInstance { get; set; }

        //Relation to Course
        public virtual Course Course { get; set; }
    }
}
