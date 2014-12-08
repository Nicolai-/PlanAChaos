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
    public class TeamInstanceCourseScenarioTests : FunctionalTest
    {
        [TestMethod]
        public void AddTeamInstanceCourseIsPersisted()
        {
            using (var bc = new BusinessContext())
            {
                var ti = new TeamInstance
                {
                    TeamInstanceName = "Prog",
                    StartDate = new DateTime(2014, 10, 22),
                    EndDate = new DateTime(2014, 12, 12)
                };
                bc.AddNewTeamInstance(ti);
                bool tiExists = bc.DataContext.TeamInstances.Any(t => t.Id == ti.Id);
                Assert.IsTrue(tiExists);

                var course = new Course
                {
                    CourseName = "Programmering IV",
                    CourseDesription = "WPF, EF, MVVM, C#, .NET",
                    CourseLength = 2
                };
                bc.AddNewCourse(course);
                bool courseExists = bc.DataContext.Courses.Any(c => c.Id == course.Id);
                Assert.IsTrue(courseExists);

                var teamInstanceCourse = new TeamInstanceCourse
                {
                    CourseId = course.Id,
                    TeamInstanceId = ti.Id,
                    Week = 43
                };

                bc.AddNewTeamInstanceCourse(teamInstanceCourse);
                bool ticExists =
                    bc.DataContext.TeamInstancesCourses.Any(
                        tic =>
                            tic.CourseId == teamInstanceCourse.CourseId &&
                            tic.TeamInstanceId == teamInstanceCourse.TeamInstanceId);
                Assert.IsTrue(ticExists);

                Assert.AreEqual("WPF, EF, MVVM, C#, .NET", bc.GetTeamInstanceCourseById(teamInstanceCourse.CourseId, teamInstanceCourse.TeamInstanceId).Course.CourseDesription);
            }
        }
    }
}
