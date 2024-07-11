using Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Database
{
    public class MyDatabase : IDatabase
    {
        public IList<Document> Documents { get; set; }

        public MyDatabase()
        {
            Documents = new List<Document>();
        }

        public void Dispose()
        {
        }

        public void AddDocument(Document document)
        {
            if (!Documents.Any(x => x.Id == document.Id))
            {
                Documents.Add(document);
            }
        }

        public Document? GetDocument(string Id)
        {
            return Documents.FirstOrDefault(x => x.Id == Id);
        }

        public void RemoveDocument(string id)
        {
            var doc = GetDocument(id);
            if (doc != null) {
                Documents.Remove(doc);
            }
        }

        public void UpdateDocument(Document document)
        {
            RemoveDocument(document.Id);
            AddDocument(document);
        }
    }
}
