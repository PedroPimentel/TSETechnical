using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TCE.Domain.Core.IRepository;
using TCE.Infrastructure.Data;

namespace TCE.Infrastructure.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly TCEDbContext _context;
        private readonly DbSet<T> _entities;
        private readonly IMapper _mapper;

        public Repository(TCEDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _entities = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _entities.ToListAsync();
        }

        public async Task<IEnumerable<TDto>> GetAllProjectedAsync<TDto>()
        {
            return await _entities.ProjectTo<TDto>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<IEnumerable<TDto>> GetProjectedAsync<TDto>(Expression<Func<T, bool>> filter)
        {
            return await _entities.Where(filter).ProjectTo<TDto>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<(IEnumerable<TDto> Data, int TotalCount)> GetPagedProjectedAsync<TDto>(Expression<Func<T, bool>> filter, int pageNumber, int pageSize)
        {
            var query = _entities.Where(filter);
            var totalCount = await query.CountAsync();
            var data = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ProjectTo<TDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return (data, totalCount);
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _entities.FindAsync(id);
        }

        public async Task AddAsync(T entity)
        {
            await _entities.AddAsync(entity);
        }

        public async Task UpdateAsync(T entity)
        {
            _entities.Update(entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _entities.FindAsync(id);
            if (entity != null)
            {
                _entities.Remove(entity);
            }
        }

    }
}
