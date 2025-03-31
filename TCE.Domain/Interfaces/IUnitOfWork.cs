using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCE.Domain.Core.IRepository
{
    public interface IUnitOfWork
    {
        IRepository<T> GetRepository<T>() where T : class;

        Task<int> SaveChangesAsync();
    }
}
