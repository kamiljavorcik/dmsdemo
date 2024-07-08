using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Repository.Tests
{
    public class MyDbSet<TEntity> : DbSet<TEntity> where TEntity : class
    {
        public override IEntityType EntityType => throw new NotImplementedException();

        public override void AddRange(IEnumerable<TEntity> entities)
        {
            //base.AddRange(entities);
        }
    }
}
