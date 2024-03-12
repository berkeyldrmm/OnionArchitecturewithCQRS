using OnionArchitecturewithCQRS.Domain.Common;
using OnionArchitecturewithCQRS.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecturewithCQRS.Application.Interfaces.Repository
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<List<T>> GetAll();
        Task<T> GetById(Guid id);
        Task<bool> AddEntity(T entity);
        Task AddRangeEntity(List<T> entites);
        Task<bool> DeleteEntity(Guid id);
        bool UpdateEntity(T entity);
        void UpdateRange(List<T> entites);

    }
}
