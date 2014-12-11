using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PAC.Data.Tests
{
    [TestClass]
    public class FunctionalTest
    {
        [TestInitialize]
        public virtual void TestInitialize()
        {
            using (var db = new DataContext())
            {
                if (db.Database.Exists())
                {
                    db.Database.Delete();
                }
            }
        }

        [TestCleanup]
        public virtual void TestCleanup()
        {
            using (var db = new DataContext())
            {
                if (db.Database.Exists())
                {
                    db.Database.Delete();
                }
            }
        }
    }
}
