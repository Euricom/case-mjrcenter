using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Euricom.MjrCenter.ScheduleApi.Utilities.Repositories
{
    public abstract class BaseRepository<TContext, T> : IBaseRepository<T>
        where TContext : DbContext
        where T : class
    {
        private readonly TContext _context;

        public BaseRepository(TContext context)
        {
            _context = context;
        }

        public IQueryable<T> All => _context.Set<T>();

        public Task Add(T entity)
        {
            return _context.AddAsync(entity);
        }

        public Task Commit()
        {
            return _context.SaveChangesAsync();
        }

        public Task Remove(T entity)
        {
            _context.Remove(entity);
            return Task.CompletedTask;
        }
    }
}