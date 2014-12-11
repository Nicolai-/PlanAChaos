using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PAC.Data.Model;

namespace PAC.Data.Tests.FunctionalTests
{
    [TestClass]
    public class TeamInstanceScenarioTests : FunctionalTest
    {
        [TestMethod]
        public void AddTeamInstanceIsPersisted()
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
                Assert.IsTrue(exists, "Team Not Persisted");

                var ti = new TeamInstance
                {
                    TeamId = team.Id,
                    TeamInstanceName = "Prog",
                    StartDate = new DateTime(2014, 10, 22),
                    EndDate = new DateTime(2014, 12, 12)
                };

                bc.AddNewTeamInstance(ti);
                bool tiExists = bc.DataContext.TeamInstances.Any(t => t.Id == ti.Id);

                Assert.IsTrue(tiExists);
                Assert.AreEqual("H1", bc.GetTeamInstanceById(ti.Id).Team.TeamName);
            }
        }
    }
}
