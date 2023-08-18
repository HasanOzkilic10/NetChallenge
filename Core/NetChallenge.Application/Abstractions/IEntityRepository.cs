using NetChallenge.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NetChallenge.Application.Abstractions
{
    public interface IEntityRepository<T> where T : BaseEntity
    {
        List<T> GetAll(Expression<Func<T , bool>> query = null);
        T GetById(Expression<Func<T, bool>> query);
        void Add(T entity); 
        void Update(T entity);  
        void Delete(T entity);  

    }
}
