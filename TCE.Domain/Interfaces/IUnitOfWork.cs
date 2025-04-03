using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCE.Domain.Common;

namespace TCE.Domain.Core.IRepository
{
    public interface IUnitOfWork
    {
        IRepository<T> GetRepository<T>() where T : BaseEntity;

        Task<int> SaveChangesAsync();
    }
}
