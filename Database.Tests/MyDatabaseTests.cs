using Database;
using Database.Models;
using System.Text;

namespace Database.Tests
{
    [TestClass]
    public class MyDatabaseTests
    {
        [TestMethod]
        public void TestInstance()
        {
            using (IDatabase db = new MyDatabase())
            {
                var doc = new Document { Id = "test" };

                db.AddDocument(doc);

                Assert.IsTrue(db.GetDocument("test") != null);
            }
        }
    }
}