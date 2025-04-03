using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TCE.Domain.Common;
using TCE.Domain.Core.IRepository;
using TCE.Infrastructure.Data;
using TCE.Infrastructure.Repository;

namespace TCE.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly TCEDbContext _context;
        private readonly Dictionary<Type, object> _repositories;
        private bool _disposed;
        private readonly IMapper _mapper;

        public UnitOfWork(TCEDbContext context, IMapper mapper)
        {
            _context = context;
            _repositories = new Dictionary<Type, object>();
            _mapper = mapper;
        }

        public IRepository<T> GetRepository<T>() where T : BaseEntity
        {
            if (_repositories.ContainsKey(typeof(T)))
            {
                return (IRepository<T>)_repositories[typeof(T)];
            }

            var repository = new Repository<T>(_context, _mapper);
            _repositories.Add(typeof(T), repository);

            return repository;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }

                _disposed = true;
            }
        }
    }
}
