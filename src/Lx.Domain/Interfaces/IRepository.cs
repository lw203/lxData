using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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
        /// 分页查询 + 条件查询 + 排序
        /// </summary>
        /// <typeparam name="Tkey">泛型</typeparam>
        /// <param name="pageSize">每页大小</param>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="total">总数量</param>
        /// <param name="whereLambda">查询条件</param>
        /// <param name="orderbyLambda">排序条件</param>
        /// <param name="isAsc">是否升序</param>
        /// <returns>IQueryable 泛型集合</returns>
        Task<IQueryable<TEntity>> GetByPage<Tkey>(int pageSize, int pageIndex, Expression<Func<TEntity, bool>> whereLambda, Func<TEntity, Tkey> orderbyLambda, bool isAsc);

        /// <summary>
        /// 获取总数量
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        Task<int> GetCount(Expression<Func<TEntity, bool>> whereLambda);

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
