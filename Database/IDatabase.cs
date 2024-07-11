using Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Database
{
    /**
     * This interface is needed for unitesting
     * And also is not neccessary to expose all methods
     */
    public interface IDatabase : IDisposable
    {
        public void AddDocument(Document document);
        public Document? GetDocument(string id);
        public void RemoveDocument(string id);
        public void UpdateDocument(Document document);
    }
}
