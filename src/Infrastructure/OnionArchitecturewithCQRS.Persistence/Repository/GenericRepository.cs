using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using OnionArchitecturewithCQRS.Application.Interfaces.Repository;
using OnionArchitecturewithCQRS.Application.Interfaces.UnitOfWork;
using OnionArchitecturewithCQRS.Domain.Common;
using OnionArchitecturewithCQRS.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecturewithCQRS.Persistence.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        public ApplicationDbContext _context { get; set; }

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddEntity(T entity)
        {
            EntityEntry<T> result = await _context.AddAsync(entity);
            return result.State == EntityState.Added;
        }

        public async Task AddRangeEntity(List<T> entites)
        {
            await _context.AddRangeAsync(entites);
        }

        public async Task<bool> DeleteEntity(Guid id)
        {
            EntityEntry<T> result = _context.Remove(await GetById(id));
            return result.State == EntityState.Deleted;
        }

        public async Task<List<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(Guid id)
        {
            T? entity = await _context.Set<T>().FindAsync(id);
            if (entity is not null)
                return entity;

            throw new ArgumentNullException(nameof(entity));
        }

        public bool UpdateEntity(T entity)
        {
            EntityEntry<T> result = _context.Update(entity);
            return result.State == EntityState.Modified;
        }

        public void UpdateRange(List<T> entites)
        {
            _context.UpdateRange(entites);
        }
    }
}
