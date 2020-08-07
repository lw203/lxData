using Lx.Domain.Interfaces;
using Lx.Infrastruct.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Lx.Infrastruct.Data.Repository
{
    /// <summary>
    /// 泛型仓储，实现泛型仓储接口
    /// </summary>
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly LxContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(LxContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public virtual void Add(TEntity obj)
        {
            DbSet.Add(obj);
        }
        public virtual void Update(TEntity obj)
        {
            DbSet.Update(obj);
        }

        public virtual void Remove(Guid id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return Db.Set<TEntity>().AsQueryable();
        }

        public virtual IQueryable<TEntity> GetByPage<Tkey>(int pageSize, int pageIndex, Expression<Func<TEntity, bool>> whereLambda, Func<TEntity, Tkey> orderbyLambda, bool isAsc)
        {
            if (isAsc)
            {
                if (pageIndex > 0 & pageSize > 0)
                {
                    var temp = Db.Set<TEntity>().Where(whereLambda)
                                 .OrderBy<TEntity, Tkey>(orderbyLambda)
                                 .Skip(pageSize * (pageIndex - 1))
                                 .Take(pageSize);
                    return temp.AsQueryable();
                }
                else
                {
                    var temp = Db.Set<TEntity>().Where(whereLambda)
                                 .OrderBy<TEntity, Tkey>(orderbyLambda);
                    return temp.AsQueryable();
                }
            }
            else
            {
                if (pageIndex > 0 & pageSize > 0)
                {
                    var temp = Db.Set<TEntity>().Where(whereLambda)
                           .OrderByDescending<TEntity, Tkey>(orderbyLambda)
                           .Skip(pageSize * (pageIndex - 1))
                           .Take(pageSize);
                    return temp.AsQueryable();
                }
                else
                {
                    var temp = Db.Set<TEntity>().Where(whereLambda)
                           .OrderByDescending<TEntity, Tkey>(orderbyLambda);
                    return temp.AsQueryable();
                }
            }
        }

        public virtual int GetCount(Expression<Func<TEntity, bool>> whereLambda)
        {
            return Db.Set<TEntity>().Where(whereLambda).Count();
        }

        public virtual TEntity GetById(Guid id)
        {
            return DbSet.Find(id);
        }

        public int SaveChanages()
        {
            return Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
