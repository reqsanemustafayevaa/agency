using Microsoft.EntityFrameworkCore;
using project.Core.Models;
using project.Core.Repositories.Interfaces;
using project.data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace project.data.Repostories.Implementations
{
    public class GenericRepostory<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity, new()
    {
        private readonly AppDbContext _context;
        public GenericRepostory(AppDbContext context)
        {
            _context=context;
        }
        public DbSet<TEntity> Table => _context.Set<TEntity>();

        public async Task<int> CommitAsync()
        {

            return await _context.SaveChangesAsync();
        }

        public async Task CreateAsync(TEntity entity)
        {
            Table.AddAsync(entity);
        }

        public void Delete(TEntity entity)
        {
            Table.Remove(entity);
        }

        public void DeleteAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public async  Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? expression = null, params string[]? includes)
        {
            var query = Table.AsQueryable();  
            GetQuery(includes);
            return expression is not null
                       ? await query.Where(expression).ToListAsync()
                       : await query.ToListAsync();

        }

        public async Task<TEntity> GetByIdAsync(Expression<Func<TEntity, bool>>? expression = null, params string[]? includes)
        {
            var query=Table.AsQueryable();

            GetQuery(includes);
            return expression is not null
                ?await query.Where(expression).FirstOrDefaultAsync()
                :await query.FirstOrDefaultAsync();
        }
        public IQueryable<TEntity> GetQuery(string[]? includes)
        {
            var query = Table.AsQueryable();
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }

            }
            return query;
        }
    }
}
