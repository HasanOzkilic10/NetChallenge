using Microsoft.EntityFrameworkCore;
using NetChallenge.Application.Abstractions;
using NetChallenge.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NetChallenge.Persistence.Concretes
{
    public class EntityRepository<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : BaseEntity
        where TContext : DbContext , new()
    {
        public void Add(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                context.Set<TEntity>().Add(entity);
            
               context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> query = null)
        {
            using (TContext context = new TContext())
            {
                return query == null ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(query).ToList();

            }
        }

        public TEntity GetById(Expression<Func<TEntity, bool>> query)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(query);
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                context.Set<TEntity>().Update(entity);
              
                context.SaveChanges();
            }

        }
    }
}

