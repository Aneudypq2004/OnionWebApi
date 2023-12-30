using Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly RepositoryContext _repository;

        public RepositoryBase(RepositoryContext repository)
        {
            this._repository = repository;
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool tranckChanges)
        {
            return tranckChanges ? _repository.Set<T>().Where(expression).AsNoTracking() : _repository.Set<T>().Where(expression);
        }

        public IQueryable<T> FindAll(bool tranckChanges)
        {
            return tranckChanges ? _repository.Set<T>().AsNoTracking() : _repository.Set<T>();
        }
        public void Create(T entity) => _repository.Set<T>().Add(entity);

        public void Delete(T entity) => _repository.Set<T>().Remove(entity);


        public void Update(T entity) => _repository.Set<T>().Update(entity);
    }
}
