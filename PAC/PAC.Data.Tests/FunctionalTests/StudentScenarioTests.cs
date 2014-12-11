using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PAC.Data.Model;

namespace PAC.Data.Tests.FunctionalTests
{
    [TestClass]
    public class StudentScenarioTests : FunctionalTest
    {

        [TestMethod]
        public void AddStudentIsPersisted()
        {
            using (var bc = new BusinessContext())
            {
                var student = new Student
                {
                    FirstName = "Jacob",
                    LastName = "Graungaard"
                };
                bc.AddNewStudent(student);

                bool exists = bc.DataContext.Students.Any(s => s.Id == student.Id);

                Assert.IsTrue(exists);
            }
        }
    }
}
