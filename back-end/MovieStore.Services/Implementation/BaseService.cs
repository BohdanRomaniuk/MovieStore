using MovieStore.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MovieStore.Services
{
    public abstract class BaseService<TEntity> : IService<TEntity>
        where TEntity : class
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected IRepository<TEntity> Repository => _unitOfWork.GetRepository<TEntity>();

        protected BaseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public virtual IEnumerable<TEntity> Get()
        {
            return Repository.Get();
        }

        public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {
            return Repository.Get(predicate);
        }

        public virtual void Add(TEntity entity)
        {
            Repository.Add(entity);
            _unitOfWork.SaveChanges();
        }

        public virtual void Remove(TEntity entity)
        {
            Repository.Remove(entity);
            _unitOfWork.SaveChanges();
        }

        public virtual void Update(TEntity entity)
        {
            Repository.Update(entity);
            _unitOfWork.SaveChanges();
        }

        public virtual TEntity Get(int id)
        {
            throw new NotImplementedException("Should be ovveriden in service");
        }

        public virtual void Remove(int id)
        {
            throw new NotImplementedException("Should be ovveriden in service");
        }
    }
}
