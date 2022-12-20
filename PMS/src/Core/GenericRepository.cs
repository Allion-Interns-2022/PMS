using Core.Interface;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Core
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected PMSContext _context { get; set; }
        protected DbSet<T> _DbSet { get; set; }
        public GenericRepository(PMSContext context) 
        {
            _context= context;
            this._DbSet=context.Set<T>();
        }

        public virtual async Task<bool> AddEntity(T entity)
        {
            await _DbSet.AddAsync(entity);
            return true;
        }

        public virtual async Task<bool> DeleteEntity(int id)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await _DbSet.ToListAsync ();
        }

        public virtual async Task<T> GetById(int id)
        {
            return await _DbSet.FindAsync(id);
        }

        public virtual async Task<bool> UpdateEntity(T entity)
        {
            throw new NotImplementedException();
        }
    }
}