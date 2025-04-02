using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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
    }
}
