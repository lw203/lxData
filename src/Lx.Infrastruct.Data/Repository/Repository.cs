using Lx.Domain.Interfaces;
using Lx.Infrastruct.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lx.Infrastruct.Data.Repository
{
    /// <summary>
    /// 泛型仓储，实现泛型仓储接口
    /// </summary>
    public class Repository<TEntiiy> : IRepository<TEntiiy> where TEntiiy : class
    {
        protected readonly StudyContext Db;
        protected readonly DbSet<TEntiiy> DbSet;

        public Repository(StudyContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntiiy>();
        }

        public virtual void Add(TEntiiy obj)
        {
            DbSet.Add(obj);
        }
        public virtual void Update(TEntiiy obj)
        {
            DbSet.Update(obj);
        }

        public virtual void Remove(Guid id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public IQueryable<TEntiiy> GetAll()
        {
            return Db.Set<TEntiiy>().AsQueryable();
        }

        public virtual TEntiiy GetById(Guid id)
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
