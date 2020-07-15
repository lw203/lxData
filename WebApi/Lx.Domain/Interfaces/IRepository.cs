using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lx.Domain.Interfaces
{
    /// <summary>
    /// 定义泛型仓储接口，并继承IDisposable，显示释放资源
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        /// <summary>
        /// 添加
        /// </summary>
        void Add(TEntity obj);

        /// <summary>
        /// 根据id获取对象
        /// </summary>
        TEntity GetById(Guid id);

        /// <summary>
        /// 获取全部列表
        /// </summary>
        IQueryable<TEntity> GetAll();

        /// <summary>
        /// 根基对象进行更新
        /// </summary>
        void Update(TEntity obj);

        /// <summary>
        /// 根据id删除
        /// </summary>
        void Remove(Guid id);

        /// <summary>
        /// 保存
        /// </summary>
        int SaveChanages();
    }
}
