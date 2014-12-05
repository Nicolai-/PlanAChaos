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
    public class StudentScenarioTests
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
