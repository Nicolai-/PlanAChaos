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
    public class TeacherScenarioTests : FunctionalTest
    {
        [TestMethod]
        public void AddTeacherIsPersisted() { 
        using (var bc = new BusinessContext())
             {
                var teacher = new Teacher
                  {
                        FirstName ="Michael",
                        LastName = "Code"
                  };
                bc.AddNewTeacher(teacher);
                bool exists = bc.DataContext.Teachers.Any(s => s.Id == teacher.Id);

                Assert.IsTrue(exists);        
             }        
        
        }
    }
}
