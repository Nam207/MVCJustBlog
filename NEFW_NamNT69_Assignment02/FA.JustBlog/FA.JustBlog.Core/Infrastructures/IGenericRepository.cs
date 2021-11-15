using FA.JustBlog.Core.Models.EntityBase;
using System;
using System.Collections.Generic;

namespace FA.JustBlog.Core.Infrastructures
{
    public interface IGenericRepository<TEntity> where TEntity : class, IBaseEntity
    {
        void Add(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity, bool isHardDelete = false);

        void Delete(int key, bool isHardDelete = false);

        IEnumerable<TEntity> GetAll();

        TEntity GetById(int key);

        IEnumerable<TEntity> Find(Func<TEntity, bool> condition);
    }
}