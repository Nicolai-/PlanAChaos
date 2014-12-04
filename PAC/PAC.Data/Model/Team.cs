using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAC.Data.Model
{
    public class Team
    {
        public int Id { get; set; }
        public int NumberOfWeeks { get; set; }
        public string TeamName { get; set; }

        //Relation to TeamInstance
        public virtual IList<TeamInstance> TeamInstances { get; set; }
    }
}
