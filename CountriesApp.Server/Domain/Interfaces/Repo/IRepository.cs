using System.Linq.Expressions;

namespace CountriesApp.Server.Domain.Interfaces.Repo;

public interface IRepository<T>
{
    public Task<IEnumerable<T>> Get(
        string? filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        Tuple<int, int>? offset = null,
        string includeProperties = ""
    );
    
}
