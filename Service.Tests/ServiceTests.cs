using Service.Models;

namespace Service.Tests
{

    /**
     * Simple Service test
     * just example no time to full implementation
     */
    [TestClass]
    public class ServiceTests
    {
        [TestMethod]
        public void CreateInstance()
        {
            var repository = new MockRepository();
            using (IService svc = new MyService(repository))
            {
                Document doc = new Document();
                svc.AddDocument(doc);
            }

            Assert.IsTrue(repository.countAddDocuments > 0);
        }
    }
}