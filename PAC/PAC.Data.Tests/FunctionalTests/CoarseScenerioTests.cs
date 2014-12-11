using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PAC.Data.Model;

namespace PAC.Data.Tests.FunctionalTests
{
    [TestClass]
    public class CourseScenerioTests : FunctionalTest
    {
        [TestMethod]
        public void AddCourseIsPersisted()
        {
            using (var bc = new BusinessContext())
            {
                var course = new Course
                  {
                      CourseName = "Programming",
                      CourseLength = 1,
                      CourseDescription = "dette er programmering"

                  };
                bc.AddNewCourse(course);

                bool exists = bc.DataContext.Courses.Any(s => s.Id == course.Id);

                Assert.IsTrue(exists);
            }

        }

    }
}
