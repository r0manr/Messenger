using System.Data.Entity;

namespace MessangerFirst.Data
{
    /// <summary>
    /// Создание экземпляра контекста
    /// </summary>
    public interface IDbContextFactory
    {
        DbContext GetContext();
    }
    public class DbContextFactory : IDbContextFactory
    {
        private readonly DbContext _dbContext;

        public DbContextFactory()
        {
            _dbContext = new Db();
        }

        public DbContext GetContext()
        {
            return _dbContext;
        }
    }
}
