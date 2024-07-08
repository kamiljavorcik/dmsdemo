using Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Database
{
    /**
     * Implementaion of IDatabase needed for unit tests for mocking
     */
    public class MyDatabase : DbContext, IDatabase
    {
        /**
         * Field are in plural because it has not to be ambiguous `Document in Documents`
         * Table Datas make no sense but we keep pattern rules rather than english grammar
         */
        public DbSet<Document> Documents { get; set; }
        public DbSet<Data> Datas { get; set; }
        public DbSet<Tag> Tags { get; set; }

        private readonly string _connectionString;

        public MyDatabase(string connectionString)
        {
            _connectionString = connectionString;
        }

        /**
         * I choose SQL server because of other implementations like InMemory or other databases are not common
         * Using InMemory database is not recomended and MDF database need SQL Server either so no difference
         * Attaching MDF file to SQL Server can cause multiple issues which can be difficult to fix for user
         */
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        public bool EnsureCreated()
        {
            return this.Database.EnsureCreated();
        }

        public void Init()
        {
            EnsureCreated();
        }

        public void Clear()
        {
            ChangeTracker.Clear();
        }
    }
}
