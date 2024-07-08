using Database;
using Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository.Tests
{
    public class MockDatabase : IDatabase
    {
        public int countClear { get; set; }
        public int countDispose { get; set; }
        public int countEnsureCreated { get; set; }
        public int countSaveChanges { get; set; }

        public DbSet<Document> Documents { get; set; }
        public DbSet<Data> Datas { get; set; }
        public DbSet<Tag> Tags { get; set; }

        public MockDatabase()
        {
            Documents = new MyDbSet<Document>();
            Datas = new MyDbSet<Data>();
            Tags = new MyDbSet<Tag>();
        }

        public void Init() { }

        public void Dispose()
        {
            countDispose++;
        }

        public bool EnsureCreated()
        {
            countEnsureCreated++;
            return false;
        }

        public int SaveChanges()
        {
            countSaveChanges++;
            return 0;
        }

        public void Clear()
        {
            countClear++;
        }
    }
}
