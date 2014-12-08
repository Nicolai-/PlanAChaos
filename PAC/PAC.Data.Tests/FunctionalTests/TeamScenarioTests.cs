using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PAC.Data.Model;

namespace PAC.Data.Tests.FunctionalTests
{
    [TestClass]
   public class TeamScenarioTests
    {
        [TestMethod]
        public void AddTeamIsPersisted()
        {
            using (var bc = new BusinessContext())
            {
                var team = new Team
                {
                   TeamName = "H1",
                   NumberOfWeeks = 10
                };
                bc.AddNewTeam(team);

                bool exists = bc.DataContext.Teams.Any(t => t.Id == team.Id);

                Assert.IsTrue(exists);
            }
        }
    }
}
