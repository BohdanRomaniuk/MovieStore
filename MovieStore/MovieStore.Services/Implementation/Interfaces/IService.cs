using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MovieStore.Services
{
    public interface IService<TEntity>
    {
        IEnumerable<TEntity> Get();
        TEntity Get(int id);
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> predicate);
        void Add(TEntity entity);
        void Remove(int id);
        void Update(TEntity entity);
    }
}
