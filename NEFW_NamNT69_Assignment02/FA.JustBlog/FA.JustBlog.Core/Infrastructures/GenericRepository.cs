using FA.JustBlog.Core.Models.EntityBase;
using FA.JustBlog.Core.Models.Enums;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core.Infrastructures
{
    public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, IBaseEntity
    {
        protected readonly JustBlogContext context;
        protected DbSet<TEntity> dbSet;

        public GenericRepository(JustBlogContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public virtual void Add(TEntity entity)
        {
            this.dbSet.Add(entity);
        }

        public virtual void Delete(TEntity entity, bool isHardDelete = false)
        {
            if (isHardDelete == false)
            {
                entity.Status = Status.IsDeleted;
                this.context.Entry<TEntity>(entity).State = EntityState.Modified;
                return;
            }
            this.dbSet.Remove(entity);
        }

        public virtual void Delete(int key, bool isHardDelete = false)
        {
            Delete(GetById(key), isHardDelete);
        }

        public virtual IEnumerable<TEntity> Find(Func<TEntity, bool> condition)
        {
            return this.dbSet.Where(condition);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return this.dbSet.ToList();
        }

        public TEntity GetById(int key)
        {
            return this.dbSet.Find(key);
        }

        public void Update(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }
    }
}
