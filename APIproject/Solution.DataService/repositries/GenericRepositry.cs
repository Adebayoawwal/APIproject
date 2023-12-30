using APIproject.Solution.DataService.Repositries.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Solution.DataService.Data;
using Solution.Enitities.dbSet;

namespace APIproject.Solution.DataService.repositries
{
    public class GenericRepositry<T> : IGenericRepositry<T> where T : class
    {
        public readonly ILogger _Logger;
        protected AppdbContext _context;
        internal DbSet<T> _dbSet;

        public GenericRepositry(AppdbContext context, ILogger logger)
        {
            _context = context;
            _Logger = logger;

            _dbSet = context.Set<T>();
        }

        public async Task<bool> Add(T entity)
        {
            await _dbSet.AddAsync(entity);
            return true;
        }

        public async Task<IEnumerable<T>> All()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<T?> GetById(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<bool> Update(T entity)
        {
            throw new NotImplementedException();
        }

    }
}
