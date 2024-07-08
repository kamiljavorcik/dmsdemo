using Repository.Models;

namespace Repository
{
    public interface IRepository : IDisposable
    {
        public void Init();
        public IQueryable<Document> GetDocuments();
        public void AddDocuments(IQueryable<Document> documents);
        public void UpdateDocuments(IQueryable<Document> documents);
        public void RemoveDocuments(IQueryable<Document> documents);
    }
}
