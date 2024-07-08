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
        public DbSet<Document> Documents { get; set; }
        public DbSet<Data> Datas { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public int SaveChanges();
        public bool EnsureCreated();
        public void Init();
        public void Clear();
    }
}
