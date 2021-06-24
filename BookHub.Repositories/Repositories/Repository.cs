using BooksHub.Data.Models;
using BooksHub.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BooksHub.Repositories.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly BooksHubContext context;

        public Repository(BooksHubContext context)
        {
            this.context = context;
        }
        public async  Task Add(TEntity entity)
        {
            await context.Set<TEntity>().AddAsync(entity); 
        }

        public async Task AddRange(IEnumerable<TEntity> entities)
        {
            await context.Set<TEntity>().AddRangeAsync(entities); 
        }
        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return context.Set<TEntity>().Where(predicate).ToList(); 
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await context.Set<TEntity>().FindAsync(id);
        }

        public void  Remove(TEntity entity)
        {
            context.Set<TEntity>().Remove(entity); 
        }

        public void Remove(int id)
        {
            TEntity entityToBeRemoved = context.Set<TEntity>().Find(id);
            if(entityToBeRemoved != null )
                context.Set<TEntity>().Remove(entityToBeRemoved);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            context.Set<TEntity>().RemoveRange(entities);
        }

        public void  Update(TEntity entity)
        {
            context.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }
    }
}
