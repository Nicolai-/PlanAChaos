using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PAC.Data.Model;

namespace PAC.Data.Tests.FunctionalTests
{
    [TestClass]
    public class TeamScenarioTests : FunctionalTest
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

        [TestMethod]
        public void EditTeamIsPersisted()
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
                string oldName = team.TeamName;
                var tmpTeam = bc.GetTeamById(team.Id);
                tmpTeam.TeamName = "H2";
                bc.EditTeam(tmpTeam);
                string savedName = bc.GetTeamById(tmpTeam.Id).TeamName;

                Assert.AreNotEqual(oldName, savedName);
                Assert.AreEqual(savedName, "H2");
            }
        }
    }
}
