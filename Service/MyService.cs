using Repository;
using Service.Models;

namespace Service
{
    public class MyService : IService
    {
        private bool disposedValue;

        private readonly IRepository _repository;

        public MyService(IRepository repository)
        {
            this._repository = repository;
        }

        public void Init()
        {
            _repository.Init();
        }

        public Document? GetDocument(Document doc)
        {
            return _repository.GetDocuments().Where(x => x.Name == doc.Name).Select(x =>
            new Document()
            {
                Id = x.Id,
                Name = x.Name,
                Tags = x.Tags.Select(y => new Tag() { Id = y.Id, Name = y.Name }).ToList(),
                Datas = x.Datas.Select(y => new Data() { Id = y.Id, Name = y.Name, Type = y.Type, Content = y.Content }).ToList(),
            }).ToList().FirstOrDefault();
        }

        public void AddDocument(Document doc)
        {
            IList<Document> list = new List<Document>() { doc };

            _repository.AddDocuments(
                list.Select(x => new Repository.Models.Document()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Tags = x.Tags.Select(y => new Repository.Models.Tag() { Id = y.Id, Name = y.Name }).ToList(),
                    Datas = x.Datas.Select(y => new Repository.Models.Data() { Id = y.Id, Name = y.Name, Type = y.Type, Content = y.Content }).ToList(),
                }).AsQueryable()
                );

        }

        public void UpdateDocument(Document doc)
        {
            IList<Document> list = new List<Document>() { doc };

            _repository.UpdateDocuments(
                list.Select(x => new Repository.Models.Document()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Tags = x.Tags.Select(y => new Repository.Models.Tag() { Id = y.Id, Name = y.Name }).ToList(),
                    Datas = x.Datas.Select(y => new Repository.Models.Data() { Id = y.Id, Name = y.Name, Type = y.Type, Content = y.Content }).ToList(),
                }).AsQueryable()
                );
        }

        public void RemoveDocument(Document doc)
        {
            IList<Document> list = new List<Document>() { doc };
            _repository.RemoveDocuments(
                 list.Select(x => new Repository.Models.Document()
                 {
                     Id = x.Id,
                     Name = x.Name,
                     Tags = x.Tags.Select(y => new Repository.Models.Tag() { Id = y.Id, Name = y.Name }).ToList(),
                     Datas = x.Datas.Select(y => new Repository.Models.Data() { Id = y.Id, Name = y.Name, Type = y.Type, Content = y.Content }).ToList(),
                 }).AsQueryable()
                );
        }


        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                    _repository.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~MyService()
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