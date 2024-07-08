using Repository;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Tests
{
    public class MockRepository : IRepository
    {
        public int countAddDocuments { get; set; }
        public int countDispose { get; set; }

        public void Init() { }
        public void AddDocuments(IQueryable<Document> documents)
        {
            countAddDocuments++;
        }

        public void RemoveDocuments(IQueryable<Document> documents)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            countDispose++;
        }

        public IQueryable<Document> GetDocuments()
        {
            throw new NotImplementedException();
        }

        public void UpdateDocuments(IQueryable<Document> documents)
        {
            throw new NotImplementedException();
        }
    }
}
