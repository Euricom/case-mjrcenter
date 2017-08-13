using System.Linq;
using System.Threading.Tasks;

namespace Euricom.MjrCenter.Shared.Data.Repositories
{
    public interface IBaseRepository<T>
        where T : class
    {
        IQueryable<T> All { get; }
        Task Add(T venue);
        Task Remove(T venue);
        Task Commit();
    }
}