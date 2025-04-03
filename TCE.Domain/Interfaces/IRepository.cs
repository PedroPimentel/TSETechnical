using System.Linq.Expressions;

namespace TCE.Domain.Core.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetByIdAsync(Guid id);
        
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<TDto>> GetAllProjectedAsync<TDto>();
        Task<IEnumerable<TDto>> GetProjectedAsync<TDto>(Expression<Func<T, bool>> filter);
        Task<(IEnumerable<TDto> Data, int TotalCount)> GetPagedProjectedAsync<TDto>(Expression<Func<T, bool>> filter, int pageNumber, int pageSize);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(Guid id);
        void Attach(T entity);
        Task<T> GetByIdAsync(Guid id, Func<IQueryable<T>, IQueryable<T>> include = null);
    }
}
