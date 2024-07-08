using Service.Models;

namespace Service
{
    public interface IService : IDisposable
    {
        public void Init();
        public Document? GetDocument(Document doc);
        public void AddDocument(Document doc);
        public void UpdateDocument(Document doc);
        public void RemoveDocument(Document doc);
    }
}
