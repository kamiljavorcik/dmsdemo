using Database;
using Repository.Models;
using System.Text;
using System.Text.Unicode;

namespace Repository
{
    public class MyRepository : IRepository
    {
        private bool disposedValue;

        private readonly IDatabase _dbContext;

        public MyRepository(IDatabase dbContext)
        {
            _dbContext = dbContext;
        }

        public void Init()
        {
            _dbContext.Init();
        }

        public IQueryable<Document> GetDocuments()
        {
            return _dbContext.Documents.Select(x => new Document()
            {
                Id = x.Id,
                Name = x.Name,
                Tags = x.Tags.Select(y => new Tag() { Id = y.Id, Name = y.Name }).ToList(),
                Datas = x.Datas.Select(y => new Data() { Id = y.Id, Name = y.Name, Type = y.Type, Content = UTF8Encoding.UTF8.GetString(y.Content) }).ToList(),
            });
        }

        public void RemoveDocuments(IQueryable<Document> documents)
        {
            _dbContext.Clear();

            _dbContext.Documents.RemoveRange(documents.Select(x => new Database.Models.Document()
            {
                Id = x.Id,
                Name = x.Name,
                Tags = x.Tags.Select(y => new Database.Models.Tag() { Id = y.Id, Name = y.Name }).ToList(),
                Datas = x.Datas.Select(y => new Database.Models.Data() { Id = y.Id, Name = y.Name, Type = y.Type, Content = UTF8Encoding.UTF8.GetBytes(y.Content) }).ToList(),
            }));
            _dbContext.SaveChanges();
        }

        public void AddDocuments(IQueryable<Document> documents)
        {
            _dbContext.Documents.AddRange(documents.Select(x => new Database.Models.Document()
            {
                Id = x.Id,
                Name = x.Name,
                Tags = x.Tags.Select(y => new Database.Models.Tag() { Id = y.Id, Name = y.Name }).ToList(),
                Datas = x.Datas.Select(y => new Database.Models.Data() { Id = y.Id, Name = y.Name, Type = y.Type, Content = UTF8Encoding.UTF8.GetBytes(y.Content) }).ToList(),
            }));

            _dbContext.SaveChanges();
        }

        public void UpdateDocuments(IQueryable<Document> documents)
        {
            _dbContext.Clear();

            _dbContext.Documents.UpdateRange(documents.Select(x => new Database.Models.Document()
            {
                Id = x.Id,
                Name = x.Name,
                Tags = x.Tags.Select(y => new Database.Models.Tag() { Id = y.Id, Name = y.Name }).ToList(),
                Datas = x.Datas.Select(y => new Database.Models.Data() { Id = y.Id, Name = y.Name, Type = y.Type, Content = UTF8Encoding.UTF8.GetBytes(y.Content) }).ToList(),
            }));

            _dbContext.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                    _dbContext.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~Database()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
