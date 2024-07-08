using Database;
using Database.Models;
using System.Text;

namespace Database.Tests
{
    [TestClass]
    public class MyDatabaseTests
    {

        /// <summary>
        /// This should be connection string for testing database
        /// </summary>
        string connectionString = "server=localhost;database=MyDatabase2;integrated security=True;Connect Timeout=30";

        /**
         * Testing of database connection
         */
        [TestMethod]
        public void CreateInstance()
        {
            using (IDatabase context = new MyDatabase(connectionString))
            {
                context.EnsureCreated();
            }
        }

        [TestMethod]
        public void CheckTables()
        {
            using (IDatabase context = new MyDatabase(connectionString))
            {
                context.EnsureCreated();
                var x = context.Documents.FirstOrDefault();
                var y = context.Datas.FirstOrDefault();
                var z = context.Tags.FirstOrDefault();
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void InsertDocument()
        {
            using (IDatabase context = new MyDatabase(connectionString))
            {
                context.EnsureCreated();
                var doc = new Models.Document()
                {
                    Id = 0,
                    Name = "test"
                };
                context.Documents.Add(doc);
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void InsertTag()
        {
            using (IDatabase context = new MyDatabase(connectionString))
            {
                context.EnsureCreated();
                var tag = new Models.Tag()
                {
                    Id = 0,
                    Name = "test"
                };
                context.Tags.Add(tag);
                context.SaveChanges();
            }
        }


        [TestMethod]
        public void InsertData()
        {
            using (IDatabase context = new MyDatabase(connectionString))
            {
                context.EnsureCreated();
                var data = new Models.Data()
                {
                    Id = 0,
                    Name = "test",
                    Content = UTF8Encoding.UTF8.GetBytes("test"),
                    Type = "test"
                };
                context.Datas.Add(data);
                context.SaveChanges();
            }
        }

    }
}