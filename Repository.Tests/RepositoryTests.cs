using Repository.Models;

namespace Repository.Tests
{

    /**
     * Repository testing
     */
    [TestClass]
    public class RepositoryTests
    {

        /**
         * Simple test if instance can be created
         */
        [TestMethod]
        public void CreateInstance()
        {
            var database = new MockDatabase();

            using (IRepository repository = new MyRepository(database))
            {
            }

        }

        /**
         * In short of time we dont check too deep
         */
        [TestMethod]
        public void AddDocument()
        {
            var database = new MockDatabase();
            using (IRepository repository = new MyRepository(database))
            {
                var doc = new Document()
                {
                    Name = "test",
                };

                var list = new List<Document>() { doc };
                repository.AddDocuments(list.AsQueryable());
            }

            /**
             * When SaveChange is called it is good enought for demo
             * In real prod there will be check of mapping in Database.DbSet<Document>
             */
            Assert.IsTrue(database.countSaveChanges > 0);

        }

    }
}
